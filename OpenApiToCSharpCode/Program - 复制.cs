using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApiToCSharpCode
{
    public class OpenApi2
    {
        public string Swagger { get; set; }
        public string Host { get; set; }
        public string BasePath { get; set; }
        public Info Info { get; set; }
        public InfoTag[] Tags { get; set; }
        public string[] Schemes { get; set; }
        public SecurityDefinitions SecurityDefinitions { get; set; }
        public Path[] Paths { get; set; }
        public Definition[] Definitions { get; set; }
        public string[] Consumes { get;  set; }
        public string[] Produces { get;  set; }
        public ExternalDoc ExternalDocs { get; set; }

    }
    public class SecurityDefinitions
    {
        [Newtonsoft.Json.JsonProperty("petstore_auth")]
        public PetstoreAuth PetstoreAuth { get; set; }
        [Newtonsoft.Json.JsonProperty("api_key")]
        public ApiKey ApiKey { get; set; }
    }
    public class PetstoreAuth
    {
        public string Type { get; set; }
        public string AuthorizationUrl { get; set; }
        public string Flow { get; set; }
        public Scopes Scopes { get; set; }

    }
    public class Scopes
    {
        [Newtonsoft.Json.JsonProperty("write:pets")]
        public string Write { get; set; }
        [Newtonsoft.Json.JsonProperty("read:pets")]
        public string Read { get; set; }
    }
    public class ApiKey
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string In { get; set; }
    }
    public class Info
    {
        //[Newtonsoft.Json.JsonArray()]
        public string Description { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string TermsOfService { get; set; }
        public Contact Contact { get; set; }
        public License License { get; set; }
    }
    public class InfoTag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExternalDoc ExternalDocs { get; set; }
    }
    public class ExternalDoc
    {
        public string url { get; set; }
        public string Description { get; set; }
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
    }
    public class License
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }
    public class Path
    {
        public string Url { get; set; }
        public Method[] Methods { get; set; }
    }
    public class Method
    {
        /// <summary>
        /// $ref,get,put,post,delete,options,head,patch
        /// </summary>
        public string Name { get; set; }
        public string[] Tags { get; set; }
        public string Description { get; set; }
        public string OperationId { get; set; }
        public string Summary { get; set; }
        public string[] Consumes { get; set; }
        public string[] Produces { get; set; }
        public Parameter[] Parameters { get; set; }
        public Response[] Responses { get; set; }
        public MethodSecurity[] Security { get; set; }
        public string[] Schemes { get;  set; }
        public bool? Deprecated { get;  set; }
        public ExternalDoc ExternalDocs { get;  set; }
    }
    public class MethodSecurity
    {
        public string Name { get; set; }
        public string[] Urls { get; set; }

    }
    public class Security
    {
        [Newtonsoft.Json.JsonProperty("petstore_auth")]
        public string[] PetstoreAuth { get; set; }
    }
    public class Response
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Schema Schema { get; set; }

    }
    public class Schema
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public Items Items { get; set; }
    }
    public class Parameter
    {
        public string Name { get; set; }
        /// <summary>
        /// query,header,path,formData,body
        /// </summary>
        public string In { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        public Schema Schema { get; set; }
        public Items Items { get;  set; }
        public string CollectionFormat { get; set; }
        
    }
    public class Definition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        //[JsonProperty(typeof(BoolConvert))]
        //[JsonConverter(typeof(BoolConvert))]
        public Property[] Properties { get; set; }
    }
    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Items Items { get; set; }
        [JsonProperty("$ref")]
        public string Ref { get; set; }
        public string[] Enum { get; set; }
        public Xml Xml { get; set; }
        
    }
    public class Xml
    {
        public string Name { get; set; }
        public bool Wrapped { get; set; }

    }
    public class Items
    {
        public string Type { get; set; }
        [JsonProperty("$ref")]
        public string Ref { get; set; }
        public string[] Enum { get; set; }
        public string Default { get; set; }
        public string Format { get; set; }
        //[JsonProperty("items")]
        //public Items _Items { get; set; }
        public string CollectionFormat { get; set; }
        public int? maximum { get; set; }
        public int? minimum { get; set; }
        public int? maxLength { get; set; }
        public int? minLength { get; set; }
        public int? maxItems { get; set; }
        public int? multipleOf { get; set; }
        public bool? exclusiveMaximum { get; set; }
        public bool? exclusiveMinimum { get; set; }
        public bool? uniqueItems { get; set; }
    }
    //public class BoolConvert : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return true;
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
//    public class OpenApi2
//    {

//        [JsonProperty("swagger")]
//        public string Swagger { get; set; }


//        [JsonProperty("host")]
//        public string Host { get; set; }

//        [JsonProperty("basePath")]
//        public string BasePath { get; set; }

//        [JsonProperty("schemes")]
//        public string[] Schemes { get; set; }
//        [JsonProperty("info")]
//        public Info Info { get; set; }

//        //[JsonProperty("paths")]
//        //public Paths Paths { get; set; }

//        [JsonProperty("securityDefinitions")]
//        public SecurityDefinitions SecurityDefinitions { get; set; }

//        [JsonProperty("definitions")]
//        public Definitions Definitions { get; set; }
//    }
//    public class Info
//    {

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("version")]
//        public string Version { get; set; }

//        [JsonProperty("title")]
//        public string Title { get; set; }

//        [JsonProperty("contact")]
//        public Contact Contact { get; set; }

//        [JsonProperty("license")]
//        public License License { get; set; }
//    }
//    public class Contact
//    {

//        [JsonProperty("name")]
//        public string Name { get; set; }
//    }

//    public class License
//    {

//        [JsonProperty("name")]
//        public string Name { get; set; }

//        [JsonProperty("url")]
//        public string Url { get; set; }
//    }
//    public class SecurityDefinitions
//    {

//        [JsonProperty("Client Credentials")]
//        public ClientCredentials ClientCredentials { get; set; }
//    }

//    public class ClientCredentials
//    {

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("type")]
//        public string Type { get; set; }

//        [JsonProperty("tokenUrl")]
//        public string TokenUrl { get; set; }

//        [JsonProperty("flow")]
//        public string Flow { get; set; }

//        [JsonProperty("scopes")]
//        public Scopes Scopes { get; set; }
//    }

//    public class Definitions
//    {

//        [JsonProperty("Error")]
//        public Error Error { get; set; }

//        [JsonProperty("ErrorParameter")]
//        public ErrorParameter ErrorParameter { get; set; }

//        [JsonProperty("AspectDistribution")]
//        public AspectDistribution AspectDistribution { get; set; }

//        [JsonProperty("AspectValueDistribution")]
//        public AspectValueDistribution AspectValueDistribution { get; set; }

//        [JsonProperty("BuyingOptionDistribution")]
//        public BuyingOptionDistribution BuyingOptionDistribution { get; set; }

//        [JsonProperty("Category")]
//        public Category2 Category { get; set; }

//        [JsonProperty("CategoryDistribution")]
//        public CategoryDistribution CategoryDistribution { get; set; }

//        [JsonProperty("ConditionDistribution")]
//        public ConditionDistribution ConditionDistribution { get; set; }

//        [JsonProperty("ConvertedAmount")]
//        public ConvertedAmount ConvertedAmount { get; set; }

//        [JsonProperty("Image")]
//        public Image Image { get; set; }

//        [JsonProperty("ItemLocationImpl")]
//        public ItemLocationImpl ItemLocationImpl { get; set; }

//        [JsonProperty("ItemSummary")]
//        public ItemSummary ItemSummary { get; set; }

//        [JsonProperty("MarketingPrice")]
//        public MarketingPrice2 MarketingPrice { get; set; }

//        [JsonProperty("PickupOptionSummary")]
//        public PickupOptionSummary PickupOptionSummary { get; set; }

//        [JsonProperty("Refinement")]
//        public Refinement Refinement { get; set; }

//        [JsonProperty("SearchPagedCollection")]
//        public SearchPagedCollection SearchPagedCollection { get; set; }

//        [JsonProperty("Seller")]
//        public Seller2 Seller { get; set; }

//        [JsonProperty("ShippingOptionSummary")]
//        public ShippingOptionSummary ShippingOptionSummary { get; set; }

//        [JsonProperty("TargetLocation")]
//        public TargetLocation TargetLocation { get; set; }

//        [JsonProperty("TimeDuration")]
//        public TimeDuration TimeDuration { get; set; }

//        [JsonProperty("AdditionalProductIdentity")]
//        public AdditionalProductIdentity AdditionalProductIdentity { get; set; }

//        [JsonProperty("Address")]
//        public Address Address { get; set; }

//        [JsonProperty("Aspect")]
//        public Aspect Aspect { get; set; }

//        [JsonProperty("AspectGroup")]
//        public AspectGroup AspectGroup { get; set; }

//        [JsonProperty("CommonDescriptions")]
//        public CommonDescriptions CommonDescriptions { get; set; }

//        [JsonProperty("EstimatedAvailability")]
//        public EstimatedAvailability EstimatedAvailability { get; set; }

//        [JsonProperty("Item")]
//        public Item Item { get; set; }

//        [JsonProperty("ItemGroupSummary")]
//        public ItemGroupSummary ItemGroupSummary { get; set; }

//        [JsonProperty("ItemReturnTerms")]
//        public ItemReturnTerms ItemReturnTerms { get; set; }

//        [JsonProperty("Items")]
//        public Items30 Items { get; set; }

//        [JsonProperty("LegalAddress")]
//        public LegalAddress LegalAddress { get; set; }

//        [JsonProperty("Product")]
//        public Product2 Product { get; set; }

//        [JsonProperty("ProductIdentity")]
//        public ProductIdentity2 ProductIdentity { get; set; }

//        [JsonProperty("RatingHistogram")]
//        public RatingHistogram RatingHistogram { get; set; }

//        [JsonProperty("Region")]
//        public Region Region { get; set; }

//        [JsonProperty("ReviewRating")]
//        public ReviewRating ReviewRating { get; set; }

//        [JsonProperty("Seller_0")]
//        public Seller0 Seller0 { get; set; }

//        [JsonProperty("SellerLegalInfo")]
//        public SellerLegalInfo2 SellerLegalInfo { get; set; }

//        [JsonProperty("ShippingOption")]
//        public ShippingOption ShippingOption { get; set; }

//        [JsonProperty("ShipToLocation")]
//        public ShipToLocation ShipToLocation { get; set; }

//        [JsonProperty("ShipToLocations")]
//        public ShipToLocations2 ShipToLocations { get; set; }

//        [JsonProperty("Taxes")]
//        public Taxes2 Taxes { get; set; }

//        [JsonProperty("TaxJurisdiction")]
//        public TaxJurisdiction2 TaxJurisdiction { get; set; }

//        [JsonProperty("TypedNameValue")]
//        public TypedNameValue TypedNameValue { get; set; }

//        [JsonProperty("VatDetail")]
//        public VatDetail VatDetail { get; set; }
//    }
//    public class Error
//    {

//        [JsonProperty("type")]
//        public string Type { get; set; }

//        [JsonProperty("properties")]
//        public Properties Properties { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }
//    }
//    public class Properties
//    {

//        [JsonProperty("category")]
//        public Category Category { get; set; }

//        [JsonProperty("domain")]
//        public Domain Domain { get; set; }

//        [JsonProperty("errorId")]
//        public ErrorId ErrorId { get; set; }

//        [JsonProperty("inputRefIds")]
//        public InputRefIds InputRefIds { get; set; }

//        [JsonProperty("longMessage")]
//        public LongMessage LongMessage { get; set; }

//        [JsonProperty("message")]
//        public Message Message { get; set; }

//        [JsonProperty("outputRefIds")]
//        public OutputRefIds OutputRefIds { get; set; }

//        [JsonProperty("parameters")]
//        public Parameters Parameters { get; set; }

//        [JsonProperty("subdomain")]
//        public Subdomain Subdomain { get; set; }
//    }
//    public class ErrorParameter
//    {

//        [JsonProperty("type")]
//        public string Type { get; set; }

//        [JsonProperty("properties")]
//        public Properties2 Properties { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }
//    }

//    public class Properties2
//    {

//        [JsonProperty("name")]
//        public Name Name { get; set; }

//        [JsonProperty("value")]
//        public Value Value { get; set; }
//    }
//    public class AspectDistribution
//    {

//        [JsonProperty("type")]
//        public string Type { get; set; }

//        [JsonProperty("properties")]
//        public Properties3 Properties { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }
//    }

//}
