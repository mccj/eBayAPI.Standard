using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eBayApi.OAuth2
{
    /// <summary>
    /// 授权相关
    /// https://developer.ebay.com/api-docs/static/ebay-rest-landing.html
    ///
    /// https://api.sandbox.ebay.com/identity/v1/oauth2/token
    /// https://api.ebay.com/identity/v1/oauth2/token
    /// </summary>
    public class OAuth2Client
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly bool _sandbox;
        public OAuth2Client(bool sandbox = false)
        {
            _httpClient = new System.Net.Http.HttpClient();
            _httpClient.BaseAddress = new Uri(_sandbox ? "https://api.sandbox.ebay.com/" : "https://api.ebay.com/");
            _sandbox = sandbox;
        }
        /// <summary>
        /// 获取授权码登入页面
        /// https://developer.ebay.com/api-docs/static/oauth-permissions-grant-request.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        /// <param name="redirectUri"></param>
        /// <param name="state"></param>
        /// <param name="scopes">
        /// 权限范围
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
        /// 不同国家的登入地址
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
        public string GetAuthorizationUrl(string clientId, string ruName, string state = "", string[] scopes = null, string url = null)
        {
            //https://auth.sandbox.ebay.com/oauth2/authorize
            //https://auth.ebay.com/oauth2/authorize
            url = url ?? (_sandbox ? "https://auth.sandbox.ebay.com/" : "https://auth.ebay.com/");
            return $"{url}oauth2/authorize?client_id={clientId}&redirect_uri={System.Web.HttpUtility.UrlEncode(ruName)}&response_type=code&state={System.Web.HttpUtility.UrlEncode(state)}&scope={System.Web.HttpUtility.UrlEncode(getAllscope(scopes))}";
            //其他授权链接
            //Your branded eBay Production Sign In (Auth'n'auth)
            //https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&runame=<ruName>&SessID=<SESSION_ID>
            //Your branded eBay Production Sign In(OAuth)
            //https://auth.ebay.com/oauth2/authorize?client_id=<client_id>&response_type=code&redirect_uri=<ruName>&scope=https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly



            //返回链接
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
                ExpiresIn = Convert.ToInt32(queryString["expires_in"])
            };
        }

        /// <summary>
        /// 获取客户端令牌
        /// https://developer.ebay.com/api-docs/static/oauth-client-credentials-grant.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        ///// <param name="redirectUri"></param>
        /// <param name="scopes">权限范围
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
        public Models.OAuthResponse GetApplicationToken(string clientId, string clientSecret, /*string redirectUri = "",*/ string[] scopes = null)
        {
            if (clientId == null) throw new Models.ApiException(400, "Missing required parameter 'clientId' when calling GetItem");
            if (clientSecret == null) throw new Models.ApiException(400, "Missing required parameter 'clientSecret' when calling GetItem");

            if (appTokenCache != null)
            {
                var oAuthResponse = appTokenCache.GetValue(_sandbox);
                if (oAuthResponse != null && oAuthResponse.AccessToken != null && oAuthResponse.AccessToken.Token != null)
                {
                    //log.Info("Returning token from cache for " + environment.ConfigIdentifier());
                    return oAuthResponse;
                }
            }

            if (scopes == null || scopes.Length == 0) //throw new Models.ApiException(400, "Missing required parameter 'scope' when calling GetItem");
                scopes = new[] { "https://api.ebay.com/oauth/api_scope" };
            var path = "/identity/v1/oauth2/token";
            var basicAuthorization = getBasicAuthorization(clientId, clientSecret);
            //var redirectUri = "";

            //var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>() {
                {"grant_type", "client_credentials" },
                //{ "redirect_uri", redirectUri},
                { "scope", getAllscope(scopes)}
            };

            var _oAuthResponse = fetchToken(path, formParams, basicAuthorization, Models.TokenType.Application);
            //Update value in cache
            if (_oAuthResponse != null && _oAuthResponse.AccessToken != null)
            {
                appTokenCache.UpdateValue(_sandbox, _oAuthResponse, _oAuthResponse.AccessToken.ExpiresOn);
            }

            return _oAuthResponse;
        }
        private static AppTokenCache appTokenCache = new AppTokenCache();

        /// <summary>
        /// 获取授权令牌
        /// https://developer.ebay.com/api-docs/static/oauth-auth-code-grant-request.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        /// <param name="code"></param>
        /// <param name="ruName"></param>
        /// <returns></returns>
        public Models.OAuthResponse GetTokenByCode(string clientId, string clientSecret, string ruName, string code)
        {
            if (clientId == null) throw new Models.ApiException(400, "Missing required parameter 'clientId' when calling GetItem");
            if (clientSecret == null) throw new Models.ApiException(400, "Missing required parameter 'clientSecret' when calling GetItem");
            if (code == null) throw new Models.ApiException(400, "Missing required parameter 'code' when calling GetItem");
            if (ruName == null) throw new Models.ApiException(400, "Missing required parameter 'ruName' when calling GetItem");

            var path = "/identity/v1/oauth2/token";
            var basicAuthorization = getBasicAuthorization(clientId, clientSecret);
            var formParams = new Dictionary<String, String>() {
                { "grant_type", "authorization_code"},
                { "redirect_uri", ruName },
                { "code", code }
            };

            return fetchToken(path, formParams, basicAuthorization, Models.TokenType.User);
        }
        /// <summary>
        /// 刷新令牌
        /// https://developer.ebay.com/api-docs/static/oauth-refresh-token-request.html
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        /// <param name="refreshtoken"></param>
        /// <param name="scopes">权限范围
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
        public Models.OAuthResponse RefreshToken(string clientId, string clientSecret, string refreshtoken, string[] scopes = null)
        {
            if (clientId == null) throw new Models.ApiException(400, "Missing required parameter 'clientId' when calling GetItem");
            if (clientSecret == null) throw new Models.ApiException(400, "Missing required parameter 'clientSecret' when calling GetItem");
            if (refreshtoken == null) throw new Models.ApiException(400, "Missing required parameter 'refreshtoken' when calling GetItem");
            //if (scope == null) throw new Models.ApiException(400, "Missing required parameter 'scope' when calling GetItem");

            var path = "/identity/v1/oauth2/token";
            var basicAuthorization = getBasicAuthorization(clientId, clientSecret);
            var formParams = new Dictionary<string, string>() {
                { "grant_type", "refresh_token"},
                { "refresh_token", refreshtoken},
                { "scope",  getAllscope(scopes)}
            };
            return fetchToken(path, formParams, basicAuthorization, Models.TokenType.User);
        }
        private string getBasicAuthorization(string clientId, string clientSecret)
        {
            var basicAuthorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret));
            return basicAuthorization;
        }
        private Models.OAuthResponse fetchToken(string path, IEnumerable<KeyValuePair<string, string>> formParams, string basicAuthorization, Models.TokenType tokenType)
        {
            using (var request_ = new System.Net.Http.FormUrlEncodedContent(formParams))
            {
                request_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", basicAuthorization);

                var response = _httpClient.PostAsync(path, request_).Result;

                return HandleApiResponse(response, tokenType);
            }
        }

        private Models.OAuthResponse HandleApiResponse(System.Net.Http.HttpResponseMessage response, Models.TokenType tokenType)
        {
            var oAuthResponse = new Models.OAuthResponse();
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                oAuthResponse.ErrorMessage = result;
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Error>(result);
                oAuthResponse.Error = err;
                //if (!string.IsNullOrWhiteSpace(err?.ErrorDescription))
                //    throw err;
                //else
                //    throw new Models.ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content.ReadAsStringAsync().Result);
                //log.Error("Error in fetching the token. Error:" + oAuthResponse.ErrorMessage);
            }
            else
            {
                var apiResponse = JsonConvert.DeserializeObject<Models.OAuthApiResponse>(result);
                oAuthResponse.TokenType = apiResponse.TokenType;
                oAuthResponse.ErrorMessage = apiResponse.ErrorMessage;

                //Set AccessToken
                var accessToken = new Models.OAuthToken
                {
                    Token = apiResponse.AccessToken,
                    ExpiresIn = apiResponse.ExpiresIn,
                    ExpiresOn = DateTime.Now.Add(new TimeSpan(0, 0, apiResponse.ExpiresIn)),
                    TokenType = tokenType
                };
                oAuthResponse.AccessToken = accessToken;

                //Set Refresh Token
                if (apiResponse.RefreshToken != null)
                {
                    var refreshToken = new Models.OAuthToken
                    {
                        Token = apiResponse.RefreshToken,
                        ExpiresIn = apiResponse.RefreshTokenExpiresIn,
                        ExpiresOn = DateTime.Now.Add(new TimeSpan(0, 0, apiResponse.RefreshTokenExpiresIn)),
                    };
                    oAuthResponse.RefreshToken = refreshToken;
                }
            }
            //log.Info("Fetched the token successfully from API");
            return oAuthResponse;
        }

        private string getAllscope(string[] scopes = null)
        {
            //https://api.ebay.com/oauth/api_scope	View public data from eBay
            //https://api.ebay.com/oauth/api_scope/sell.marketing.readonly	View your eBay marketing activities, such as ad campaigns and listing promotions
            //https://api.ebay.com/oauth/api_scope/sell.marketing	View and manage your eBay marketing activities, such as ad campaigns and listing promotions
            //https://api.ebay.com/oauth/api_scope/sell.inventory.readonly	View your inventory and offers
            //https://api.ebay.com/oauth/api_scope/sell.inventory	View and manage your inventory and offers
            //https://api.ebay.com/oauth/api_scope/sell.account.readonly	View your account settings
            //https://api.ebay.com/oauth/api_scope/sell.account	View and manage your account settings
            //https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly	View your order fulfillments
            //https://api.ebay.com/oauth/api_scope/sell.fulfillment	View and manage your order fulfillments
            //https://api.ebay.com/oauth/api_scope/sell.analytics.readonly	View your selling analytics data, such as performance reports
            //https://api.ebay.com/oauth/api_scope/sell.finances	View and manage your payment and order information to display this information to you and allow you to initiate refunds using the third party application

            // https://api.ebay.com/oauth/api_scope/commerce.identity.readonly
            // https://api.ebay.com/oauth/api_scope/commerce.identity.name.readonly
            // https://api.ebay.com/oauth/api_scope/commerce.identity.address.readonly
            // https://api.ebay.com/oauth/api_scope/commerce.identity.email.readonly
            // https://api.ebay.com/oauth/api_scope/commerce.identity.phone.readonly

            return string.Join(" ", (scopes?.Any() == true) ? scopes : new[] {
                "https://api.ebay.com/oauth/api_scope",
                "https://api.ebay.com/oauth/api_scope/sell.marketing.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.marketing",
                "https://api.ebay.com/oauth/api_scope/sell.inventory.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.inventory",
                "https://api.ebay.com/oauth/api_scope/sell.account.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.account",
                "https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly",
                //"https://api.ebay.com/oauth/api_scope/sell.fulfillment",
                "https://api.ebay.com/oauth/api_scope/sell.analytics.readonly",
                "https://api.ebay.com/oauth/api_scope/sell.finances"

                //"https://api.ebay.com/oauth/api_scope/commerce.identity.readonly",
                //"https://api.ebay.com/oauth/api_scope/commerce.identity.name.readonly",
                //"https://api.ebay.com/oauth/api_scope/commerce.identity.address.readonly",
                //"https://api.ebay.com/oauth/api_scope/commerce.identity.email.readonly",
                //"https://api.ebay.com/oauth/api_scope/commerce.identity.phone.readonly"
            });
        }

        public class AppTokenCacheModel
        {
            public Models.OAuthResponse OAuthResponse { get; set; }
            public DateTime ExpiresAt { get; set; }
        }
        private class AppTokenCache
        {
            private Dictionary<bool, AppTokenCacheModel> envAppTokenCache = new Dictionary<bool, AppTokenCacheModel>();

            public void UpdateValue(bool sandbox, Models.OAuthResponse oAuthResponse, DateTime expiresAt)
            {
                AppTokenCacheModel appTokenCacheModel = new AppTokenCacheModel
                {
                    OAuthResponse = oAuthResponse,

                    //Setting a buffer of 5 minutes for refresh
                    ExpiresAt = expiresAt.Subtract(new TimeSpan(0, 5, 0))
                };

                //Remove key if it exists
                if (envAppTokenCache.ContainsKey(sandbox))
                {
                    envAppTokenCache.Remove(sandbox);
                }

                envAppTokenCache.Add(sandbox, appTokenCacheModel);
            }

            public Models.OAuthResponse GetValue(bool sandbox)
            {
                AppTokenCacheModel appTokenCacheModel = this.envAppTokenCache.TryGetValue(sandbox, out AppTokenCacheModel value) ? value : null;
                if (appTokenCacheModel != null)
                {
                    if ((appTokenCacheModel.OAuthResponse != null && appTokenCacheModel.OAuthResponse.ErrorMessage != null)
                        || (DateTime.Now.CompareTo(appTokenCacheModel.ExpiresAt) < 0))
                        return appTokenCacheModel.OAuthResponse;
                }
                //Since the value is expired, return null
                return null;
            }
        }
    }
}
namespace eBayApi.OAuth2.Models
{
    public class ApiException : Exception
    {
        public ApiException(int statusCode, string message) : base(message)
        {
            this.HResult = statusCode;
        }
        public ApiException(int statusCode, string message, string response) : base(message)
        {
            this.HResult = statusCode;
        }
    }
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
        public int ExpiresIn { get => _expiresIn; set { _expiresIn = value; ExpiresOn = DateTimeOffset.Now.Add(new TimeSpan(0, 0, value)); } }
        private int _expiresIn;
        public System.DateTimeOffset ExpiresOn { get; private set; }
    }
    public class OAuthApiResponse
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
        public int RefreshTokenExpiresIn { get; set; }
        [DataMember(Name = "errorMessage", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "errorMessage")]
        public String ErrorMessage { get; set; }
    }


    public class OAuthResponse
    {
        public OAuthToken AccessToken { get; set; }
        public OAuthToken RefreshToken { get; set; }
        public String ErrorMessage { get; set; }
        public Models.Error Error { get; set; }
        public string TokenType { get; set; }
        public bool IsSuccess => Error == null && string.IsNullOrEmpty(ErrorMessage);
    }
    public class OAuthToken
    {
        public String Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public TokenType TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
    public enum TokenType
    {
        User,
        Application
    }
}