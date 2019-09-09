using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    public class OAuth2Initialize
    {
        public static void Initialize()
        {
            var ebayconfig = @"
name: ebay-config
api.sandbox.ebay.com:
    appid: <appid-from-developer-portal>
    certid: <certid-from-developer-portal>
    devid: <devid-from-developer-portal>
    redirecturi: <redirect_uri-from-developer-portal>
Api.ebay.com:
    appid: <appid-from-developer-portal>
    certid: <certid-from-developer-portal>
    devid: <devid-from-developer-portal>
    redirecturi: <redirect_uri-from-developer-portal>
";
            var ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(ebayconfig));

            //eBay.ApiClient.Auth.OAuth2.CredentialUtil.Load("YAML config file path");
            //or
            eBay.ApiClient.Auth.OAuth2.CredentialUtil.Load(new System.IO.StreamReader(ms));
        }
    }
}
