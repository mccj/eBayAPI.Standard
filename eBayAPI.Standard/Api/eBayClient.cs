using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eBayApi
{
    public partial class eBayClient
    {
        //public eBayApi.Buy.Browse.BrowseClient Browse { get; set; } = new eBayApi.Buy.Browse.BrowseClient("https://api.ebay.com/buy/marketing/v1_beta");

        //public void SetAuthorization(string oAuthToken)
        //{
        //    Browse.ApiClient.AddDefaultHeader("Authorization", "Bearer "+ oAuthToken);
        //}
        public int Timeout { set { Setting(f => f.ApiClient.RestClient.Timeout = value); } }
        public string UserAgent { set { Setting(f => f.ApiClient.RestClient.UserAgent = value); } }
        public int? MaxRedirects { set { Setting(f => f.ApiClient.RestClient.MaxRedirects = value); } }
        public X509CertificateCollection ClientCertificates { set { Setting(f => f.ApiClient.RestClient.ClientCertificates = value); } }
        public IWebProxy Proxy { set { Setting(f => f.ApiClient.RestClient.Proxy = value); } }
        public int ReadWriteTimeout { set { Setting(f => f.ApiClient.RestClient.ReadWriteTimeout = value); } }
        public Encoding Encoding { set { Setting(f => f.ApiClient.RestClient.Encoding = value); } }
        public string Authorization { set { SetAuthorization(value); } }
        public void SetAuthorization(string oAuthToken)
        {
            Setting(f => f.ApiClient.DefaultHeader["Authorization"] = "Bearer " + oAuthToken);
        }
    }
}