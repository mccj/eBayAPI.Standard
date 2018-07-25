using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace System.Linq
{
    public static class ApiExceptionExtensions
    {
        public static ErrorInfo<eBayApi.Buy.Browse.Models.Error> GetBuyBrowseError(this Api.Client.ApiException apiException)
        {
            try
            {
                var errJson = apiException.ErrorContent as string;
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorInfo<eBayApi.Buy.Browse.Models.Error>>(errJson);
                return err;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static ErrorInfo<eBayApi.Buy.Marketing.Models.Error> GetBuyMarketingError(this Api.Client.ApiException apiException)
        {
            try
            {
                var errJson = apiException.ErrorContent as string;
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorInfo<eBayApi.Buy.Marketing.Models.Error>>(errJson);
                return err;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static ErrorInfo<eBayApi.Sell.Fulfillment.Models.Error> GetSellFulfillmentError(this Api.Client.ApiException apiException)
        {
            try
            {
                var errJson = apiException.ErrorContent as string;
                var err = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorInfo<eBayApi.Sell.Fulfillment.Models.Error>>(errJson);
                return err;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    public class ErrorInfo<T> : Exception
    {
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "errors")]
        public T[] Errors { get; set; }

        public override string Message => string.Join("\r\n", Errors);
    }
}