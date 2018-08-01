using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace eBayApi.Standard.Test
{
    [TestClass]
    public class Identity
    {
        private eBayApi.eBayClient client;
        private string clientId;
        private string clientSecret;
        private string ruName;
        [TestInitialize]
        public void Initialization()
        {
            clientId = "test";
            clientSecret = "test";
            ruName = "test";

            client = new eBayApi.eBayClient();
        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        public void GetTokenOk()
        {
            //正常获取
            var token1 = client.Identity.GetToken(clientId, clientSecret);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(token1?.AccessToken), "授权值错误");
        }
        [TestMethod]
        public void GetTokenErr()
        {
            //错误授权
            Assert.ThrowsException<eBayApi.Identity.Models.Error>(() =>
            {
                var clientId2 = "test";
                var clientSecret2 = "test";
                var token2 = client.Identity.GetToken(clientId2, clientSecret2);
            });
        }

        [TestMethod]
        public void GetAuthorizationUrl()
        {
            //错误授权
            var url = client.Identity.GetAuthorizationUrl(clientId, ruName, "name=test&age=16");
            Assert.IsTrue(url.StartsWith($"https://auth.ebay.com/oauth2/authorize?client_id={clientId}&redirect_uri={ruName}&response_type=code&state=name%3dtest%26age%3d16&scope="));
        }


        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        public void GetTokenByCode()
        {
            var url = "";
            var code = client.Identity.GetAuthorizationCodeByUrl(url);
            var token1 = client.Identity.GetTokenByCode(clientId, clientSecret, ruName, code.Code);

            var token2 = client.Identity.RefreshToken(clientId, clientSecret, token1.RefreshToken);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(token2?.AccessToken), "授权值错误");
        } 
    }
}
