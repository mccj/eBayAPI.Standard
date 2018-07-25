using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace eBayApi.Standard.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var itemid = "202117468662";
            //var itemid = "111635764160";
            var sss = new eBayApi.eBayClient();
            sss.SetAuthorization("v^1.1#i^1#p^1#f^0#I^3#r^0#t^H4sIAAAAAAAAAOVXW2wUVRjeW9sUBI0YSpombgfQipnZM7e9jOzK0oKtoRe7pZESgmdnzpSR3ZnNnFm6G4nWIhBCgyClBDAIaox9MEGRh0YR6oNKlJDYRI2YvpgYL6iBEDQRjWdml7KtBCpUQuK+bOY///nP933/ZeaA3vLKRVsat/w2y13hOdQLej1uNzsTVJaXPTzb66kuc4ESB/eh3gW9vj7v94sxTKcyUjvCGUPHyJ9Lp3QsOcYolTV1yYBYw5IO0whLliwl4s0rJI4BUsY0LEM2UpS/qSFKCaIAZTHJCeEkp7IcIFb9SswOg6xDASXlCICqIgghBMk6xlnUpGML6laU4gAbpkGI5oQOwEpCROI4huXYLsrfiUysGTpxYQAVc+BKzl6zBOv1oUKMkWmRIFSsKb480RpvaljW0rE4UBIrVtQhYUEriyc+1RsK8nfCVBZd/xjseEuJrCwjjKlArHDCxKBS/AqYm4DvSI0QH0Q8p/BCWASsGJwWKZcbZhpa18dhWzSFVh1XCemWZuVvpChRI/k0kq3iUwsJ0dTgt/+eyMKUpmrIjFLLlsZXxdvaqFja/gUjUKZlGIK0wAZFOsLzLI2AHFK5kCiGUPGQQqSixJNOqTd0RbMFw/4Ww1qKCGI0WRe+RBfi1Kq3mnHVstGU+vFX9GNDXXZCCxnMWut0O6coTUTwO483Vn98t2WZWjJrofEIkxcceaIUzGQ0hZq86NRhsXRyOEqts6yMFAj09PQwPTxjmN0BDgA28GTzioS8DqVJoxV87V7PYe3GG2jNoSIjshNrkpXPECw5UqcEgN5NxcQgJ3JF2Seiik22/sNQQjkwsRmmrTmC4VBYUDkQEUFYUbnpaI5YsT4DNg6UhHk6Dc31yMqkoIxomZRZNo1MTZF4UeX4sIpoJRhRaSGiqnRSVII0qyIEEEqSARj+v/TIVKs8IRsZ1GakNDk/bbU+LXXOm0obNK18AqVSxDDVir8mSWyTvH307F6fCkU7BiZBYEZj7LpmZCMdMCCZZ7ZprYP6lnhr5DV4RyWVECww1ZTC+4tx6DJ4g8yYCBtZk7y6mVZ7pHcY65FOusQyjVQKmZ3sLSkxvcP89g/ya5KSUxpRce2dRuxfTMibLGto3TGMfX3uZoc1K/IcHwlGgreW03onpx352zmvppLURgNbSPkPvjsCEy9AMZfzY/vcx0Cf+21yhwIBsJCdD2rLvSt93ruqsWYhRoMqg7VunXzXm4hZj/IZqJmecvfqmiNDa0uuXIfWgHnjl65KLzuz5AYGaq6ulLF3V81iwyDECYAVIhzXBeZfXfWxc333wblV56Kekf7usH/rq6vu+XrNX9wcMGvcye0uc5FacPXUb6/99fia2Kb2PQuHLtWPCXXpV/qeuf/Ehct/fHPg88c6Fv3u6x/6Yc7Ifvn4hYPnj5bVnf6076fWrqO1L7vg2J7+M4fLZ7i6xhofiW1o6P+xrWpo9q7zdcqlrzxLRvfde7h9V274PHcmUjF6bHDvLw+ufGjz4uELA+f2exeNjKZXS6/XpH0nqlZv69x3dnDwu23eGbWX6R5+e3Cg+qT3hU9cLz3VxBzMfHFq+OdI9aXeSm2Ufvx4ULz455EW60D73rnPtyzwDLz14ekdS0599ujwt5vf3J31VOx+Mffeazvbn50xLzewaWTso/6VG7984OzextzHNe8cPbml+bn0xTMfVNSJO3ccGHp349Y33i+k728VaFA2DA8AAA==");
            try
            {
                //var rrr = sss.Browse.GetItemByLegacyId(itemid);
                var aaa = sss.Browse.GetItem("v1|111635764160|0");

            }
            catch (Api.Client.ApiException ex)
            {
                var ssss = ex.GetBuyBrowseError();
                if (ssss.Errors.FirstOrDefault()?.ErrorId == 11006)
                {
                    var ssssddd = sss.Browse.GetItemsByItemGroup(itemid);
                }
                throw;
            }
        }
    }
}
