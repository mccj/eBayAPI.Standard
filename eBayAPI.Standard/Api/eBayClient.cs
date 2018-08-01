using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eBayApi
{
    public partial class eBayClient
    {
        private readonly bool _sandbox;
        public eBayClient(bool sandbox = false)
        {
            _sandbox = sandbox;

            Initialization();
            InitializationGeneration();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="func"></param>
        private void Initialization(Func<string, Api.Client.ApiBase> func = null)
        {
            keyValuesApiClient["Identity"] = func?.Invoke("Identity") ?? new Identity.IdentityClient(replaceApiHostUrl("https://api.ebay.com/identity/v1/"), _sandbox);
        }
        private string replaceApiHostUrl(string url)
        {
            var replaceValue = "{apiUrl}";
            var ebayHostUrl = "https://api.ebay.com";
            var ebaySandboxHostUrl = "https://api.sandbox.ebay.com";
            return url.Replace(ebaySandboxHostUrl, replaceValue).Replace(ebayHostUrl, replaceValue).Replace(replaceValue, _sandbox ? ebaySandboxHostUrl : ebayHostUrl);
        }
        public Identity.IdentityClient Identity { get { return keyValuesApiClient["Identity"] as Identity.IdentityClient; } }

        #region 设置操作
        public int Timeout { set { Setting(f => f.ApiClient.RestClient.Timeout = value); } }
        public string UserAgent { set { Setting(f => f.ApiClient.RestClient.UserAgent = value); } }
        public int? MaxRedirects { set { Setting(f => f.ApiClient.RestClient.MaxRedirects = value); } }
        public X509CertificateCollection ClientCertificates { set { Setting(f => f.ApiClient.RestClient.ClientCertificates = value); } }
        public IWebProxy Proxy { set { Setting(f => f.ApiClient.RestClient.Proxy = value); } }
        public int ReadWriteTimeout { set { Setting(f => f.ApiClient.RestClient.ReadWriteTimeout = value); } }
        public Encoding Encoding { set { Setting(f => f.ApiClient.RestClient.Encoding = value); } }
        public string Authorization { set { SetAuthorization(value); } }

        public eBayClient SetAuthorization(string oAuthToken)
        {
            Setting(f => f.ApiClient.DefaultHeader["Authorization"] = "Bearer " + oAuthToken);
            return this;
        }
        private void Setting(Action<Api.Client.ApiBase> execute)
        {
            foreach (var item in keyValuesApiClient)
            {
                execute(item.Value);
            }
        }

        #endregion 设置操作   
        #region 授权

        /// <summary>
        /// https://developer.ebay.com/api-docs/static/rest-response-components.html
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshtoken"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public string GetDeals(string clientId, string clientSecret, string refreshtoken, string scope = "https://api.ebay.com/oauth/api_scope/sell.account%20https://api.ebay.com/oauth/api_scope/sell.inventory")
        {
            //https://api.sandbox.ebay.com/buy/v1/deals
            //https://api.ebay.com/buy/v1/deals
            var apiClient = new RestClient("https://api.ebay.com/buy/v1/");
            var request = new RestRequest("deals", Method.GET);

            request.AddParameter("scope ", scope, ParameterType.GetOrPost);
            var rr = apiClient.Post<Dictionary<string, string>>(request);
            var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(rr.Content);


            return "";
            //          {
            //  “access_token”：“ v ^ 1.1＃i...AjRV4yNjA = ”，
            //  “expires_in”：7200，
            //  “token_type”：“用户访问令牌”
            //}
        }
        #endregion 授权
    }
}