using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class eBayApiClientAuthOAuth2Test
    {
        public eBayApiClientAuthOAuth2Test()
        {
            var ebayconfig = @"
name: ebay-config


api.sandbox.ebay.com:
    appid: mmmmm6c49-9bd2-4ca3-ae07-db76cf2c5d2
    certid: 17efc6e6-e9fc-441c-a7a0-6a43a932a8ca
    devid: 678bc87a-7a84-4445-8249-2d65d56f0b32
    redirecturi: mmmmm-mmmmm6c49-9bd2--dhscnzf


api.ebay.com:
    appid: mmmmm69ac-ca7a-4165-9331-e0c7f27557e
    certid: d56ae126-2192-4942-bff1-9fabeccfc918
    devid: 678bc87a-7a84-4445-8249-2d65d56f0b32
    redirecturi: mmmmm-mmmmm69ac-ca7a--vpyba
";
            var ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(ebayconfig));

            //eBay.ApiClient.Auth.OAuth2.CredentialUtil.Load("YAML config file path");
            //or
            eBay.ApiClient.Auth.OAuth2.CredentialUtil.Load(new System.IO.StreamReader(ms));
        }
        [TestMethod]
        public void CredentialUtilTest()
        {
            var Production_AppId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.APP_ID);
            var Production_CertId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.CERT_ID);
            var Production_DevId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.DEV_ID);
            var Production_RedirectUrl = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.REDIRECT_URI);

            var Sandbox_AppId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.SANDBOX)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.APP_ID);
            var Sandbox_CertId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.SANDBOX)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.CERT_ID);
            var Sandbox_DevId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.SANDBOX)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.DEV_ID);
            var Sandbox_RedirectUrl = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.SANDBOX)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.REDIRECT_URI);

            Assert.IsNotNull(Production_AppId);
            Assert.IsNotNull(Production_CertId);
            Assert.IsNotNull(Production_DevId);
            Assert.IsNotNull(Production_RedirectUrl);
            Assert.IsNotNull(Sandbox_AppId);
            Assert.IsNotNull(Sandbox_CertId);
            Assert.IsNotNull(Sandbox_DevId);
            Assert.IsNotNull(Sandbox_RedirectUrl);
        }
        [Ignore]
        [TestMethod]
        public void CredentialUtilTest11()
        {
            var oAuth2Api = new eBay.ApiClient.Auth.OAuth2.OAuth2Api();
            var environment = eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION;
            var scopes = new System.Collections.Generic.List<string>()
            {
                //��Ȩ������Ȩ����
                "https://api.ebay.com/oauth/api_scope",//�鿴������Ȥ�Ĺ�������
                //"https://api.ebay.com/oauth/api_scope/sell.marketing.readonly",//�鿴������ȤӪ�����������ϵ�к��б����
                //"https://api.ebay.com/oauth/api_scope/sell.marketing",//�鿴�͹���������ȤӪ�����������ϵ�к��б����
                //"https://api.ebay.com/oauth/api_scope/sell.inventory.readonly",//�鿴���Ŀ����Ż�
                //"https://api.ebay.com/oauth/api_scope/sell.inventory",//�鿴�͹������Ĺ����Դ���Ż�
                //"https://api.ebay.com/oauth/api_scope/sell.account.readonly",//�鿴�����ʻ�����
                //"https://api.ebay.com/oauth/api_scope/sell.account",//	�鿴�͹��������ʻ�����
                //"https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly",//�鿴���Ķ�������
                //"https://api.ebay.com/oauth/api_scope/sell.fulfillment",//�鿴�͹������Ķ�������
                //"https://api.ebay.com/oauth/api_scope/sell.analytics.readonly",//�鿴�������۷������ݣ�����Ч������
                //"https://api.ebay.com/oauth/api_scope/sell.finances"//�鿴�͹������ĸ���Ͷ�����Ϣ���Ա�������ʾ����Ϣ����������ʹ�õ�����Ӧ�ó��������˿�
                ////�ͻ�ƾ֤��������
                //"https://api.ebay.com/oauth/api_scope"//�鿴������Ȥ�Ĺ�������
            };
            var authorizationUrl = oAuth2Api.GenerateUserAuthorizationUrl(environment, scopes, "state");
            var applicationToken = oAuth2Api.GetApplicationToken(environment, scopes);
            var accessToken1 = oAuth2Api.ExchangeCodeForAccessToken(environment, "code");
            var accessToken2 = oAuth2Api.GetAccessToken(environment, "refreshToken", scopes);
        }
    }
}
