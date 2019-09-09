using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace eBayApi.Standard.Test
{
    [TestClass]
    public class BuyBrowseTest
    {
        private eBayApi.eBayClient client;
        [TestInitialize]
        public void Initialization()
        {
            UnitTestProject.OAuth2Initialize.Initialize();

           var clientId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.APP_ID);
          var  clientSecret = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.CERT_ID);
            //var ruName = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.REDIRECT_URI);



            client = new eBayApi.eBayClient();
            var sss = client.OAuth2.GetApplicationToken(clientId, clientSecret);
            var access_token = sss.AccessToken.Token;
            client.SetAuthorization(access_token);
        }

        //[TestMethod]
        //public void GetAuthorizationRefreshToken()
        //{
        //    var token1 = client.Identity.GetAuthorizationRefreshToken(clientId, clientSecret, "", "");
        //    Assert.Fail();
        //}


        [TestMethod]
        //[Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        public void TestMethod1()
        {
            var itemid = "273944393737";
            //var itemid = "111635764160";
            try
            {
                //var rrr = client.BuyBrowse.GetItemByLegacyId(itemid);
                var aaa = client.BuyBrowse.GetItem("v1|273944393737|0");
                Assert.IsNotNull(aaa.Title);
            }
            catch (ApiException ex)
            {
                //var ssss = ex.GetBuyBrowseError();
                //if (ssss.Errors.FirstOrDefault()?.ErrorId == 11006)
                //{
                //    var ssssddd = client.BuyBrowse.GetItemsByItemGroup(itemid);
                //}
                throw ex;
            }
        }
    }
}
