using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace eBayApi.Standard.Test
{
    [TestClass]
    public class Browse
    {
        private eBayApi.eBayClient client;
        //private string clientId;
        //private string clientSecret;
        //private string ruName;
        [TestInitialize]
        public void Initialization()
        {
            //clientId = "test";
            //clientSecret = "test";
            //ruName = "test";
            var access_token = "";

            client = new eBayApi.eBayClient();
            client.SetAuthorization(access_token);
        }

        //[TestMethod]
        //public void GetAuthorizationRefreshToken()
        //{
        //    var token1 = client.Identity.GetAuthorizationRefreshToken(clientId, clientSecret, "", "");
        //    Assert.Fail();
        //}


        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        public void TestMethod1()
        {
            var itemid = "202117468662";
            //var itemid = "111635764160";
            try
            {
                //var rrr = sss.Browse.GetItemByLegacyId(itemid);
                var aaa = client.BuyBrowse.GetItem("v1|111635764160|0");

            }
            catch (Api.Client.ApiException ex)
            {
                var ssss = ex.GetBuyBrowseError();
                if (ssss.Errors.FirstOrDefault()?.ErrorId == 11006)
                {
                    var ssssddd = client.Browse.GetItemsByItemGroup(itemid);
                }
                throw;
            }
        }
    }
}
