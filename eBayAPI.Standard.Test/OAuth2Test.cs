using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace eBayApi.Standard.Test
{
    [TestClass]
    public class OAuth2Test
    {
        private eBayApi.eBayClient client;
        private string clientId;
        private string clientSecret;
        private string ruName;
        [TestInitialize]
        public void Initialization()
        {
            UnitTestProject.OAuth2Initialize.Initialize();

            clientId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.APP_ID); 
            clientSecret = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.CERT_ID);
            ruName = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.REDIRECT_URI);

            client = new eBayApi.eBayClient();
        }
        [TestMethod]
        //[Ignore]
        public void GetTokenOk()
        {
            //正常获取
            var token = client.OAuth2.GetApplicationToken(clientId, clientSecret);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(token?.AccessToken?.Token), "授权值错误");
            Assert.IsTrue(token.IsSuccess);
        }
        [TestMethod]
        public void GetTokenErr()
        {
            //错误授权
            var clientId2 = "test";
            var clientSecret2 = "test";
            var token = client.OAuth2.GetApplicationToken(clientId2, clientSecret2);
            //Assert.IsTrue(!string.IsNullOrWhiteSpace(token?.AccessToken?.Token), "授权值错误");
            Assert.IsTrue(token.IsSuccess);
        }

        [TestMethod]
        public void GetAuthorizationUrl()
        {
            //错误授权
            var url = client.OAuth2.GetAuthorizationUrl(clientId, ruName, url: "https://auth.ebay.de/");
            Assert.IsTrue(url.StartsWith($"https://auth.ebay.com/oauth2/authorize?client_id={clientId}&redirect_uri={ruName}&response_type=code&state=name%3dtest%26age%3d16&scope="));
        }


        [TestMethod]
        //[Ignore]
        public void GetTokenByCode()
        {
            var url = "https://xx.xxxx.com.cn/ManagePlatform/eBay/aw-secure/auth_thanks.aspx?code=v%5E1.1%23i%5E1%23f%5E0%23p%5E3%23I%5E3%23r%5E1%23t%5EUl41Xzg6RDYwNDNCMTNGMzE3OTk4OTE2MzYyQkEzMjUyNDc2NDRfMl8xI0VeMjYw&expires_in=299";
            var code = client.OAuth2.GetAuthorizationCodeByUrl(url);
            var token1 = client.OAuth2.GetTokenByCode(clientId, clientSecret, ruName, code.Code);

            var token2 = client.OAuth2.RefreshToken(clientId, clientSecret, token1.RefreshToken?.Token);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(token2?.AccessToken?.Token), "授权值错误");
            //AccessToken
            //v^1.1#i^1#f^0#r^0#p^3#I^3#t^H4sIAAAAAAAAAOVYa2wUVRTu9kXKszzkUSBup5goOLt3Zuctu7ptt+kCbZfuQqSIeGfmTjtldmYzM9t2QwKVlxiNGkCCRKTGBOGHCkYT0YbwQ9QfBhFi+NEEQ+IDRUETiYZEcGb7oK1CqUvMJs5uMplzzz33fN/57mMGdJeWLd5Rv+P3KZ4JhT3doLvQ4yEmgbLSkiVTiworSgrAMAdPT/ei7uItRZeWWjCppYRmZKUM3ULerqSmW0LWGMTSpi4Y0FItQYdJZAm2JMTDDSsE0geElGnYhmRomDdaG8QoUmIokRcBJUGC4wKOVR+MmTCCGKQQB/kAImhIMqzbbFlpFNUtG+p2ECMBwePA/ScAIxCEAFgfTzEtmHc1Mi3V0B0XH8BC2WyFbF9zWKp3zhRaFjJtJwgWiobr4k3haG2kMbHUPyxWaICGuA3ttDXyqcaQkXc11NLozsNYWW8hnpYkZFmYP9Q/wsigQngwmX+RfpZpkRJlTgIU4l2iaXBPqKwzzCS075yHa1FlXMm6Cki3VTszFqMOG2I7kuyBp0YnRLTW695WpqGmKioyg1ikOrxmVTzSjHnjsZhpdKgykl2kBEewNCAIjsRCqfaUzQOGHRijP9AAw6MGqTF0WXX5sryNhl2NnITRaFrAMFocpya9yQwrtpvMcD9uiD6yxa1nfwHTdpvulhQlHQ682cexyR9Uw6363ys9yIjjFARphiEpRWJuN7XcuT4uTYTcsoRjMb+bCxJhBk9CcwOyUxqUEC459KaTyFRlIUArZMBJAZcZXsEpXlFwkZYZnFAQAgiJosRz/xNp2LapimkbDcljdEMWXxBz6RRUqAi2sQHpiUwKYaM9swvOgCa6rCDWZtspwe/v7Oz0dQZ8htnqJwEg/I83rIhLbSgJsSFfdWxnXM2qQ0JOL0sVbCeBINbliM8ZXG/FQs2RuuZIvH59oml5pHFQuCMyC4223gZpHEkmsvMLHctGGvwdNayqJo0YUBOJlupqVa/W/VbHiniCXVNvK7HV6UZDjrYGcwMvGSkUMzRVyvynDLhzfUwWAqYcg6adiSNNcww5AbVcoPlVZLe/5QSAKdXnTjefZCT9BnRWa9e0Ppux926c/JZDkK9/7XMij6OPqnc4S4BhZsbRB0qSkXa2lbvvoaQ1RdW07GY0jnF0qGVsVbJ8JoKyoWuZnAQQTqWiyWTahqKGonJ+KYFmSJrMGV2egUq6F8NDKbuvS5CFOEUwNM4HAgSOgMQqJEvTLMoJd0OrmmewCZ7kKI7mGBoALidstagj32rKsJwocU4lWchROEVRNM6RFI+TMkPLNKMAMZCbjms01Vkl8u+4UW9YNpJzg+YcifMLlFMxiAiSwUlHtM6xmCJxUVEInFegiCRJkXjirhU8YCim/uGA+bfXCv/IN/pQQfYitnjeB1s8xwo9HuAHDxBVoLK0aFVx0eQKS7WRzzmM+iy1VXfeVE3k24AyKaiahaUeddfZZ74a9g2hZx2YO/QVoayImDTskwJYcKulhJg2ZwrBA/fHEARgW0DVrdZiYnbxrBcnf37+62erLt5Ye6S654mz6zczf7wOpgw5eTwlBcVbPAVV264tDBW07k/c/KaiaMcyrvmh4K6P+6L3zcQ8yz9d2P4hQYZmTNzz8KyTN+bWlh832p+hni/3bp+3Ca/pK9pWeaqk91glMW0rRZ05+PbMo6ePtF+vK289eOK74zu7j367/UHro+mRA299Fjiz5+DETSfqFrz3xieP/rLp6vze+Ud3H2574cLJ07/9eaL3cun1mzVnKlX6lY0zdndFuZc3nrOML/YdunCxdvrUX79vOTRh81yrJ7Dy3cmvVhxb1Hvoh3X7d25dUlUeleifD5Ql5z3Wt/9a+J21O/d98OTeq8uvnL//qdk/Kg2nXvqyZlnv5UcuHT5Xv7i672Jz3eHXtr753JWTbU+H7LMLQiXqnJ/2sv3l+wvuh0NF3REAAA==
            //2019-09-09 16:11:09

            //RefreshToken
            //v^1.1#i^1#I^3#r^1#p^3#f^0#t^Ul4xMF84OkVFRUE5MzlDN0Q1MzMzMDYzM0U3NzdDNTQxNjgzRDY0XzNfMSNFXjI2MA==
            //2021-03-10 2:11:09

        }
    }
}
