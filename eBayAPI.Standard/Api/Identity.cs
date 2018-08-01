using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eBayApi.Identity
{
    /// <summary>
    /// ��Ȩ���
    /// https://developer.ebay.com/api-docs/static/ebay-rest-landing.html
    ///
    /// https://api.sandbox.ebay.com/identity/v1/oauth2/token
    /// https://api.ebay.com/identity/v1/oauth2/token
    /// </summary>
    public class IdentityClient : Api.Client.ApiBase
    {
        private readonly bool _sandbox;
        public IdentityClient(Api.Client.ApiClient apiClient = null, bool sandbox = false) : base(apiClient) { _sandbox = sandbox; }
        public IdentityClient(string basePath, bool sandbox = false) : base(basePath) { _sandbox = sandbox; }

        /// <summary>
        /// ��ȡ�ͻ�������
        /// https://developer.ebay.com/api-docs/static/oauth-client-credentials-grant.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        ///// <param name="redirectUri"></param>
        /// <param name="scope">Ȩ�޷�Χ
        /// https://api.ebay.com/oauth/api_scope	View public data from eBay
        /// https://api.ebay.com/oauth/api_scope/sell.marketing.readonly	View your eBay marketing activities, such as ad campaigns and listing promotions
        /// https://api.ebay.com/oauth/api_scope/sell.marketing	View and manage your eBay marketing activities, such as ad campaigns and listing promotions
        /// https://api.ebay.com/oauth/api_scope/sell.inventory.readonly	View your inventory and offers
        /// https://api.ebay.com/oauth/api_scope/sell.inventory	View and manage your inventory and offers
        /// https://api.ebay.com/oauth/api_scope/sell.account.readonly	View your account settings
        /// https://api.ebay.com/oauth/api_scope/sell.account	View and manage your account settings
        /// https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly	View your order fulfillments
        /// https://api.ebay.com/oauth/api_scope/sell.fulfillment	View and manage your order fulfillments
        /// https://api.ebay.com/oauth/api_scope/sell.analytics.readonly	View your selling analytics data, such as performance reports
        /// /// </param>
        /// <returns></returns>
        public Models.TokenInfo GetToken(string clientId, string clientSecret, /*string redirectUri = "",*/ string scope = null)
        {
            if (clientId == null) throw new Api.Client.ApiException(400, "Missing required parameter 'clientId' when calling GetItem");
            if (clientSecret == null) throw new Api.Client.ApiException(400, "Missing required parameter 'clientSecret' when calling GetItem");
            //if (scope == null) throw new Api.Client.ApiException(400, "Missing required parameter 'scope' when calling GetItem");

            var path = "/oauth2/token";
            var redirectUri = "";

            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();


            headerParams.Add("Content-Type", "application/x-www-form-urlencoded");
            headerParams.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            formParams.Add("grant_type", "client_credentials");
            formParams.Add("redirect_uri", redirectUri);
            formParams.Add("scope", scope ?? getAllscope());


            // make the HTTP request
            var response = ApiClient.CallApi(path, Method.POST, null, null, headerParams, formParams, null, null);

            if (((int)response.StatusCode) >= 400)
            {
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Error>(response.Content);
                if (!string.IsNullOrWhiteSpace(err?.ErrorDescription))
                    throw err;
                else
                    throw new Api.Client.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
                throw new Api.Client.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

            return (Models.TokenInfo)ApiClient.Deserialize(response.Content, typeof(Models.TokenInfo), response.Headers);
        }
        /// <summary>
        /// ��ȡ��Ȩ�����ҳ��
        /// https://developer.ebay.com/api-docs/static/oauth-permissions-grant-request.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        /// <param name="redirectUri"></param>
        /// <param name="state"></param>
        /// <param name="scope">
        /// Ȩ�޷�Χ
        /// https://api.ebay.com/oauth/api_scope	View public data from eBay
        /// https://api.ebay.com/oauth/api_scope/sell.marketing.readonly	View your eBay marketing activities, such as ad campaigns and listing promotions
        /// https://api.ebay.com/oauth/api_scope/sell.marketing	View and manage your eBay marketing activities, such as ad campaigns and listing promotions
        /// https://api.ebay.com/oauth/api_scope/sell.inventory.readonly	View your inventory and offers
        /// https://api.ebay.com/oauth/api_scope/sell.inventory	View and manage your inventory and offers
        /// https://api.ebay.com/oauth/api_scope/sell.account.readonly	View your account settings
        /// https://api.ebay.com/oauth/api_scope/sell.account	View and manage your account settings
        /// https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly	View your order fulfillments
        /// https://api.ebay.com/oauth/api_scope/sell.fulfillment	View and manage your order fulfillments
        /// https://api.ebay.com/oauth/api_scope/sell.analytics.readonly	View your selling analytics data, such as performance reports
        /// </param>
        /// <param name="url">
        /// ��ͬ���ҵĵ����ַ
        /// https://auth.ebay.com/
        /// https://auth.ebay.at/
        /// https://auth.ebay.com.au/
        /// https://auth.befr.ebay.be/
        /// https://auth.benl.ebay.be/
        /// https://auth.ebay.ca/
        /// https://auth.cafr.ebay.ca/
        /// https://auth.ebay.ch/
        /// https://auth.ebay.de/
        /// https://auth.ebay.es/
        /// https://auth.ebay.fr/
        /// https://auth.ebay.co.uk/
        /// https://auth.ebay.com.hk/
        /// https://auth.ebay.ie/
        /// https://auth.ebay.in/
        /// https://auth.ebay.it/
        /// https://auth.ebay.com.my/
        /// https://auth.ebay.nl/
        /// https://auth.ebay.ph/
        /// https://auth.ebay.pl/
        /// https://auth.ebay.com.sg/
        /// https://auth.ebay.co.th/
        /// https://auth.ebay.com.tw/
        /// https://auth.ebay.vn/
        /// https://auth.ebay.com/motors/
        /// </param>
        /// <returns></returns>
        ///
        public string GetAuthorizationUrl(string clientId, string ruName, string state = "", string scope = null, string url = null)
        {
            //https://auth.sandbox.ebay.com/oauth2/authorize
            //https://auth.ebay.com/oauth2/authorize
            url = url ?? (_sandbox ? "https://auth.sandbox.ebay.com/" : "https://auth.ebay.com/");
            return $"{url}oauth2/authorize?client_id={clientId}&redirect_uri={ApiClient.EscapeString(ruName)}&response_type=code&state={ApiClient.EscapeString(state)}&scope={ApiClient.EscapeString(scope?? getAllscope())}";
            //������Ȩ����
            //Your branded eBay Production Sign In (Auth'n'auth)
            //https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&runame=<ruName>&SessID=<SESSION_ID>
            //Your branded eBay Production Sign In(OAuth)
            //https://auth.ebay.com/oauth2/authorize?client_id=<client_id>&response_type=code&redirect_uri=<ruName>&scope=https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly



            //��������
            //https://www.example.com/acceptURL.html?isAuthSuccessful=true&state=name%3Dtest%26age%3D16&code=v%5E1.1%23i%5E1%23r%5E1%23I%5E3%23p%5E3%23f%5E0%23t%5EUl41XzE6ODlFQkNFMDlDREQ4OENCRTdEQzNBRTYzMzIwMTY1QUZfMF8xI0VeMjYw&expires_in=299
            //client_id	The client_id value for the environment you're targeting.
            //redirect_uri	The RuName value for the environment you're targeting.
            //response_type	Set to "code" to have eBay generate and return an authorization code.
            //scope	A list of OAuth scopes that specify the resources needing access.
            //state	An opaque value used by the client to maintain state between the request and callback.
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Models.CodeState GetAuthorizationCodeByUrl(string url)
        {
            //https://www.example.com/acceptURL.html?isAuthSuccessful=true&state=name%3Dtest%26age%3D16&code=v%5E1.1%23i%5E1%23r%5E1%23I%5E3%23p%5E3%23f%5E0%23t%5EUl41XzE6ODlFQkNFMDlDREQ4OENCRTdEQzNBRTYzMzIwMTY1QUZfMF8xI0VeMjYw&expires_in=299

            var uri = new Uri(url);
            var query = uri.Query;
            var queryString = System.Web.HttpUtility.ParseQueryString(query);
            return new Models.CodeState
            {
                IsAuthSuccessful = queryString["isAuthSuccessful"],
                State = queryString["state"],
                Code = queryString["code"],
                ExpiresIn = queryString["expires_in"]
            };
        }

        /// <summary>
        /// ��ȡ��Ȩ����
        /// https://developer.ebay.com/api-docs/static/oauth-auth-code-grant-request.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        /// <param name="code"></param>
        /// <param name="ruName"></param>
        /// <returns></returns>
        public Models.TokenInfo GetTokenByCode(string clientId, string clientSecret, string ruName, string code)
        {
            if (clientId == null) throw new Api.Client.ApiException(400, "Missing required parameter 'clientId' when calling GetItem");
            if (clientSecret == null) throw new Api.Client.ApiException(400, "Missing required parameter 'clientSecret' when calling GetItem");
            if (code == null) throw new Api.Client.ApiException(400, "Missing required parameter 'code' when calling GetItem");
            if (ruName == null) throw new Api.Client.ApiException(400, "Missing required parameter 'ruName' when calling GetItem");

            var path = "/oauth2/token";

            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();


            headerParams.Add("Content-Type", "application/x-www-form-urlencoded");
            headerParams.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            formParams.Add("grant_type", "authorization_code");
            formParams.Add("redirect_uri", ruName);
            formParams.Add("code", code);

            // make the HTTP request
            var response = ApiClient.CallApi(path, Method.POST, null, null, headerParams, formParams, null, null);

            if (((int)response.StatusCode) >= 400)
            {
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Error>(response.Content);
                if (!string.IsNullOrWhiteSpace(err?.ErrorDescription))
                    throw err;
                else
                    throw new Api.Client.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
                throw new Api.Client.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

            return (Models.TokenInfo)ApiClient.Deserialize(response.Content, typeof(Models.TokenInfo), response.Headers);
        }
        /// <summary>
        /// ˢ������
        /// https://developer.ebay.com/api-docs/static/oauth-refresh-token-request.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        /// <param name="refreshtoken"></param>
        /// <param name="scope">Ȩ�޷�Χ
        /// https://api.ebay.com/oauth/api_scope	View public data from eBay
        /// https://api.ebay.com/oauth/api_scope/sell.marketing.readonly	View your eBay marketing activities, such as ad campaigns and listing promotions
        /// https://api.ebay.com/oauth/api_scope/sell.marketing	View and manage your eBay marketing activities, such as ad campaigns and listing promotions
        /// https://api.ebay.com/oauth/api_scope/sell.inventory.readonly	View your inventory and offers
        /// https://api.ebay.com/oauth/api_scope/sell.inventory	View and manage your inventory and offers
        /// https://api.ebay.com/oauth/api_scope/sell.account.readonly	View your account settings
        /// https://api.ebay.com/oauth/api_scope/sell.account	View and manage your account settings
        /// https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly	View your order fulfillments
        /// https://api.ebay.com/oauth/api_scope/sell.fulfillment	View and manage your order fulfillments
        /// https://api.ebay.com/oauth/api_scope/sell.analytics.readonly	View your selling analytics data, such as performance reports
        /// </param>
        /// <returns></returns>
        public Models.TokenInfo RefreshToken(string clientId, string clientSecret, string refreshtoken, string scope = null)
        {
            if (clientId == null) throw new Api.Client.ApiException(400, "Missing required parameter 'clientId' when calling GetItem");
            if (clientSecret == null) throw new Api.Client.ApiException(400, "Missing required parameter 'clientSecret' when calling GetItem");
            if (refreshtoken == null) throw new Api.Client.ApiException(400, "Missing required parameter 'refreshtoken' when calling GetItem");
            //if (scope == null) throw new Api.Client.ApiException(400, "Missing required parameter 'scope' when calling GetItem");

            var path = "/oauth2/token";

            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();


            headerParams.Add("Content-Type", "application/x-www-form-urlencoded");
            headerParams.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            formParams.Add("grant_type", "refresh_token");
            formParams.Add("refresh_token", refreshtoken);
            formParams.Add("scope", scope?? getAllscope());

            // make the HTTP request
            var response = ApiClient.CallApi(path, Method.POST, null, null, headerParams, formParams, null, null);

            if (((int)response.StatusCode) >= 400)
            {
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Error>(response.Content);
                if (!string.IsNullOrWhiteSpace(err?.ErrorDescription))
                    throw err;
                else
                    throw new Api.Client.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
                throw new Api.Client.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

            return (Models.TokenInfo)ApiClient.Deserialize(response.Content, typeof(Models.TokenInfo), response.Headers);
        }

        private string getAllscope()
        {
            // https://api.ebay.com/oauth/api_scope	View public data from eBay
            // https://api.ebay.com/oauth/api_scope/sell.marketing.readonly	View your eBay marketing activities, such as ad campaigns and listing promotions
            // https://api.ebay.com/oauth/api_scope/sell.marketing	View and manage your eBay marketing activities, such as ad campaigns and listing promotions
            // https://api.ebay.com/oauth/api_scope/sell.inventory.readonly	View your inventory and offers
            // https://api.ebay.com/oauth/api_scope/sell.inventory	View and manage your inventory and offers
            // https://api.ebay.com/oauth/api_scope/sell.account.readonly	View your account settings
            // https://api.ebay.com/oauth/api_scope/sell.account	View and manage your account settings
            // https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly	View your order fulfillments
            // https://api.ebay.com/oauth/api_scope/sell.fulfillment	View and manage your order fulfillments
            // https://api.ebay.com/oauth/api_scope/sell.analytics.readonly	View your selling analytics data, such as performance reports

            return string.Join(" ", new[] {
                "https://api.ebay.com/oauth/api_scope",
                "https://api.ebay.com/oauth/api_scope/sell.marketing.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.marketing",
                "https://api.ebay.com/oauth/api_scope/sell.inventory.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.inventory",
                "https://api.ebay.com/oauth/api_scope/sell.account.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.account",
                "https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.fulfillment",
            "https://api.ebay.com/oauth/api_scope/sell.analytics.readonly"
            });
        }
    }
}
namespace eBayApi.Identity.Models
{
    public class Error : Exception
    {
        public Error(
            [JsonProperty(PropertyName = "error")]
            string errorMessage,
            [JsonProperty(PropertyName = "error_description")]
            string errorDescription
            ) : base(errorMessage)
        {
            this.ErrorDescription = errorDescription;
        }
        public string ErrorDescription { get; }
    }
    public class CodeState
    {
        public string IsAuthSuccessful { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
        public string ExpiresIn { get; set; }
    }
    public class TokenInfo
    {
        [DataMember(Name = "access_token", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        [DataMember(Name = "refresh_token", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }
        [DataMember(Name = "token_type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [DataMember(Name = "refresh_token_expires_in", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "refresh_token_expires_in")]
        public string RefreshTokenExpiresIn { get; set; }
    }

}