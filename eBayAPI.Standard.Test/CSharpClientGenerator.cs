//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//namespace eBayApi.Standard.Test
//{
//    [TestClass]
//    public class CSharpClientGeneratorTest
//    {
//        //[TestInitialize]
//        //public void Initialization()
//        //{
//        //}
//        [TestMethod]
//        //[Ignore]
//        public void GetTokenOk()
//        {
//            var document1 = NSwag.OpenApiDocument.FromUrlAsync("https://developer.ebay.com/api-docs/master/buy/browse/openapi/2/buy_browse_v1_beta_oas2.json").Result;
//            var document2 = NSwag.OpenApiYamlDocument.FromUrlAsync("https://developer.ebay.com/api-docs/master/buy/browse/openapi/2/buy_browse_v1_beta_oas2.yaml").Result;
//            var document3 = NSwag.OpenApiDocument.FromUrlAsync("https://developer.ebay.com/api-docs/master/buy/browse/openapi/3/buy_browse_v1_beta_oas3.json").Result;
//            var document4 = NSwag.OpenApiYamlDocument.FromUrlAsync("https://developer.ebay.com/api-docs/master/buy/browse/openapi/3/buy_browse_v1_beta_oas3.yaml").Result;
//            var settings = new NSwag.CodeGeneration.CSharp.CSharpClientGeneratorSettings
//            {
//                ClassName = "MyClass",
//                CSharpGeneratorSettings =
//                {
//                    Namespace = "MyNamespace"
//                }
//            };
//            var generator1 = new NSwag.CodeGeneration.CSharp.CSharpClientGenerator(document1, settings);
//            var code1 = generator1.GenerateFile();
//            var generator2 = new NSwag.CodeGeneration.CSharp.CSharpClientGenerator(document3, settings);
//            var code2 = generator2.GenerateFile();
//        }
//    }
//}
