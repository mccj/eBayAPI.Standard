using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace eBayApi.Standard.Test
{
    [TestClass]
    public class SellFulfillmentTest
    {
        private eBayApi.eBayClient client;
        [TestInitialize]
        public void Initialization()
        {
            UnitTestProject.OAuth2Initialize.Initialize();

            var clientId = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.APP_ID);
            var clientSecret = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.CERT_ID);
            //ruName = eBay.ApiClient.Auth.OAuth2.CredentialUtil.GetCredentials(eBay.ApiClient.Auth.OAuth2.Model.OAuthEnvironment.PRODUCTION)?.Get(eBay.ApiClient.Auth.OAuth2.Model.CredentialType.REDIRECT_URI);



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
            try
            {
               //var rrr= client.BuyIdentity.GetUser();
                var aaa = client.SellFulfillment.GetOrder("312727176732-947717215021");//040148949
                //var aaa = client.SellFulfillment.GetOrder("312470484629-939315634021");//020382891
                var phone = aaa.FulfillmentStartInstructions.FirstOrDefault()?.ShippingStep?.ShipTo?.PrimaryPhone;

              var dddd=  client.SellFulfillment.GetShippingFulfillments("00340434198142003963");
                //Assert.IsNotNull(aaa.Title);
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
