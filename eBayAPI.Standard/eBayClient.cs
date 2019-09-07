using System;
using System.Net.Http;

namespace eBayApi
{
    public partial class eBayClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        public eBayClient() : this(new System.Net.Http.HttpClient())
        {
            //var handler = new HttpClientHandler();
            //var handler = new NSUrlSessionHandler();
            //var handler = new SocketsHttpHandler();
            //var handler = new WinHttpHandler();
            //var handler = CFNetworkHandler();
        }
        public eBayClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        #region 设置操作
        public TimeSpan Timeout { set => _httpClient.Timeout = value; }
        public string UserAgent { set => _httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(value)); }

        [Obsolete("use HttpClientHandler.Credentials")]
        public System.Security.Cryptography.X509Certificates.X509CertificateCollection ClientCertificates { set => throw new Exception("use HttpClientHandler.Credentials"); }
        [Obsolete("use HttpClientHandler.Proxy")]
        public System.Net.IWebProxy Proxy { set => throw new Exception("use HttpClientHandler.Proxy");  }
        //public int? MaxRedirects { set { Setting(f => f.ApiClient.RestClient.MaxRedirects = value); } }
        //public int ReadWriteTimeout { set { Setting(f => f.ApiClient.RestClient.ReadWriteTimeout = value); } }
        //public Encoding Encoding { set { Setting(f => _httpClient.Encoding = value); } }
        public string BearerAuthorization { set { SetAuthorization(value); } }

        public eBayClient SetAuthorization(string oAuthToken)
        {
            _httpClient.SetBearerToken(oAuthToken);
            return this;
        }
        #endregion 设置操作   
        #region 客户端属性
        public OAuth2.OAuth2Client OAuth2 => new OAuth2.OAuth2Client(_httpClient);

        public Buy.Browse.Client BuyBrowse => new Buy.Browse.Client(_httpClient);
        public Buy.Feed.Client BuyFeed => new Buy.Feed.Client(_httpClient);
        public Buy.Identity.Client BuyIdentity => new Buy.Identity.Client(_httpClient);
        public Buy.Marketing.Client BuyMarketing => new Buy.Marketing.Client(_httpClient);
        public Buy.Marketplace.Insights.Client BuyMarketplaceInsights => new Buy.Marketplace.Insights.Client(_httpClient);
        public Buy.Offer.Client BuyOffer => new Buy.Offer.Client(_httpClient);
        public Buy.Order.Client BuyOrder => new Buy.Order.Client(_httpClient);
        public Commerce.Catalog.Client CommerceCatalog => new Commerce.Catalog.Client(_httpClient);
        public Commerce.Taxonomy.Client CommerceTaxonomy => new Commerce.Taxonomy.Client(_httpClient);
        public Commerce.Translation.Client CommerceTranslation => new Commerce.Translation.Client(_httpClient);
        public Sell.Account.Client SellAccount => new Sell.Account.Client(_httpClient);
        public Sell.Analytics.Client SellAnalytics => new Sell.Analytics.Client(_httpClient);
        public Sell.Compliance.Client SellCompliance => new Sell.Compliance.Client(_httpClient);
        public Sell.Finances.Client SellFinances => new Sell.Finances.Client(_httpClient);
        public Sell.Fulfillment.Client SellFulfillment => new Sell.Fulfillment.Client("", _httpClient);
        public Sell.Inventory.Client SellInventory => new Sell.Inventory.Client(_httpClient);
        public Sell.Logistics.Client SellLogistics => new Sell.Logistics.Client(_httpClient);
        public Sell.Marketing.Client SellMarketing => new Sell.Marketing.Client(_httpClient);
        public Sell.Metadata.Client SellMetadata => new Sell.Metadata.Client(_httpClient);
        public Sell.Recommendation.Client SellRecommendation => new Sell.Recommendation.Client(_httpClient);
        #endregion 客户端属性
    }
}
