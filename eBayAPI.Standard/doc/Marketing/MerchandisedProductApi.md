# IO.Swagger.Api.MerchandisedProductApi

All URIs are relative to *https://api.ebay.com/buy/marketing/v1_beta*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAlsoBoughtByProduct**](MerchandisedProductApi.md#getalsoboughtbyproduct) | **GET** /merchandised_product/get_also_bought_products | 
[**GetAlsoViewedByProduct**](MerchandisedProductApi.md#getalsoviewedbyproduct) | **GET** /merchandised_product/get_also_viewed_products | 
[**GetMerchandisedProducts**](MerchandisedProductApi.md#getmerchandisedproducts) | **GET** /merchandised_product | 


<a name="getalsoboughtbyproduct"></a>
# **GetAlsoBoughtByProduct**
> BestSellingProductResponse GetAlsoBoughtByProduct (string brand = null, string epid = null, string gtin = null, string mpn = null)



This call returns products that were also bought when shoppers bought the product specified in the request. Showing 'also bought' products inspires up-selling and cross-selling. You specify the product by one of the following. epid (eBay Product Id) gtin (Global Trade Item Number) brand (brand name such as Nike) plus mpn (Manufacturer's Part Number) Restrictions For a list of supported sites and other restrictions, see API Restrictions. Maximum: A maximum of 12 products are returned. The call will return up to 12 products, but it can be less than 12. If the number of products found is less than 12, the call will return all of the products matching the criteria.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAlsoBoughtByProductExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: Client Credentials
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MerchandisedProductApi();
            var brand = brand_example;  // string | The brand of the product. Restriction: This must be used along with mpn. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 
            var epid = epid_example;  // string | The eBay product identifier of a product. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 
            var gtin = gtin_example;  // string | The unique Global Trade Item Number of the item as defined by http://www.gtin.info. This can be a UPC (Universal Product Code), EAN (European Article Number), or an ISBN (International Standard Book Number value. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 
            var mpn = mpn_example;  // string | The manufacturer part number of the product. Restriction: This must be used along with brand. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 

            try
            {
                BestSellingProductResponse result = apiInstance.GetAlsoBoughtByProduct(brand, epid, gtin, mpn);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MerchandisedProductApi.GetAlsoBoughtByProduct: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **brand** | **string**| The brand of the product. Restriction: This must be used along with mpn. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 
 **epid** | **string**| The eBay product identifier of a product. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 
 **gtin** | **string**| The unique Global Trade Item Number of the item as defined by http://www.gtin.info. This can be a UPC (Universal Product Code), EAN (European Article Number), or an ISBN (International Standard Book Number value. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 
 **mpn** | **string**| The manufacturer part number of the product. Restriction: This must be used along with brand. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 

### Return type

[**BestSellingProductResponse**](BestSellingProductResponse.md)

### Authorization

[Client Credentials](../README.md#Client Credentials)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getalsoviewedbyproduct"></a>
# **GetAlsoViewedByProduct**
> BestSellingProductResponse GetAlsoViewedByProduct (string brand = null, string epid = null, string gtin = null, string mpn = null)



This call returns products that were also viewed when shoppers viewed the product specified in the request. Showing 'also viewed' products encourages up-selling and cross-selling. You specify the product by one of the following. epid (eBay Product Id) gtin (Global Trade Item Number) brand (brand name such as Nike) plus mpn (Manufacturer's Part Number) Restrictions For a list of supported sites and other restrictions, see API Restrictions. Maximum: A maximum of 12 products are returned. The call will return up to 12 products, but it can be less than 12. If the number of products found is less than 12, the call will return all of the products matching the criteria.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAlsoViewedByProductExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: Client Credentials
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MerchandisedProductApi();
            var brand = brand_example;  // string | The brand of the product. Restriction: This must be used along with mpn. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 
            var epid = epid_example;  // string | The eBay product identifier of a product. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 
            var gtin = gtin_example;  // string | The unique Global Trade Item Number of the item as defined by http://www.gtin.info. This can be a UPC (Universal Product Code), EAN (European Article Number), or an ISBN (International Standard Book Number value. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. (optional) 
            var mpn = mpn_example;  // string | The manufacturer part number of the product. Restriction: This must be used along with brand. (optional) 

            try
            {
                BestSellingProductResponse result = apiInstance.GetAlsoViewedByProduct(brand, epid, gtin, mpn);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MerchandisedProductApi.GetAlsoViewedByProduct: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **brand** | **string**| The brand of the product. Restriction: This must be used along with mpn. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 
 **epid** | **string**| The eBay product identifier of a product. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 
 **gtin** | **string**| The unique Global Trade Item Number of the item as defined by http://www.gtin.info. This can be a UPC (Universal Product Code), EAN (European Article Number), or an ISBN (International Standard Book Number value. Required: You must specify one epid, or one gtin, or one brand plus mpn pair. | [optional] 
 **mpn** | **string**| The manufacturer part number of the product. Restriction: This must be used along with brand. | [optional] 

### Return type

[**BestSellingProductResponse**](BestSellingProductResponse.md)

### Authorization

[Client Credentials](../README.md#Client Credentials)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmerchandisedproducts"></a>
# **GetMerchandisedProducts**
> BestSellingProductResponse GetMerchandisedProducts (string categoryId, string metricName, string aspectFilter = null, string limit = null)



This call returns an array of products based on the category and metric specified. This includes details of the product, such as the eBay product Id (EPID), title, and user reviews and ratings for the product. You can use the epid returned by this call in the Browse API search call to retrieve items for this product. Restrictions For a list of supported sites and other restrictions, see API Restrictions.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetMerchandisedProductsExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: Client Credentials
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MerchandisedProductApi();
            var categoryId = categoryId_example;  // string | This query parameter limits the products returned to a specific eBay category. The list of eBay category Ids is not published and category Ids are not all the same across all the eBay maketplace. You can use the following techniques to find a category by site. Use the Category Changes page. Use the Taxonomy API. For details see Categories for Buy API Calls. Use the Browse API and submit the following call to get the dominantCategoryId for an item. /buy/browse/v1/item_summary/search?q=keyword&amp;fieldgroups=ASPECT_REFINEMENTS Maximum: 1 Required: 1
            var metricName = metricName_example;  // string | This value filters the result set by the specified metric. Only products in this metric are returned. Currently, the only metric supported is BEST_SELLING. Default: BEST_SELLING Maximum: 1 Required: 1
            var aspectFilter = aspectFilter_example;  // string | The aspect name/value pairs used to further refine product results. For example: &nbsp;&nbsp;&nbsp;/buy/marketing/v1_beta/merchandised_product?category_id=31388&amp;metric_name=BEST_SELLING&amp;aspect_filter=Brand:Canon You can use the Browse API search call with the fieldgroups=ASPECT_REFINEMENTS field to return the aspects of a product. For implementation help, refer to eBay API documentation at https://developer.ebay.com/devzone/rest/api-ref/marketing/types/MarketingAspectFilter.html (optional) 
            var limit = limit_example;  // string | This value specifies the maximum number of products to return in a result set. Note: Maximum value means the call will return up to that many products per set, but it can be less than this value. If the number of products found is less than this value, the call will return all of the products matching the criteria. Default: 8 Maximum: 100 (optional) 

            try
            {
                BestSellingProductResponse result = apiInstance.GetMerchandisedProducts(categoryId, metricName, aspectFilter, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MerchandisedProductApi.GetMerchandisedProducts: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **categoryId** | **string**| This query parameter limits the products returned to a specific eBay category. The list of eBay category Ids is not published and category Ids are not all the same across all the eBay maketplace. You can use the following techniques to find a category by site. Use the Category Changes page. Use the Taxonomy API. For details see Categories for Buy API Calls. Use the Browse API and submit the following call to get the dominantCategoryId for an item. /buy/browse/v1/item_summary/search?q&#x3D;keyword&amp;amp;fieldgroups&#x3D;ASPECT_REFINEMENTS Maximum: 1 Required: 1 | 
 **metricName** | **string**| This value filters the result set by the specified metric. Only products in this metric are returned. Currently, the only metric supported is BEST_SELLING. Default: BEST_SELLING Maximum: 1 Required: 1 | 
 **aspectFilter** | **string**| The aspect name/value pairs used to further refine product results. For example: &amp;nbsp;&amp;nbsp;&amp;nbsp;/buy/marketing/v1_beta/merchandised_product?category_id&#x3D;31388&amp;amp;metric_name&#x3D;BEST_SELLING&amp;amp;aspect_filter&#x3D;Brand:Canon You can use the Browse API search call with the fieldgroups&#x3D;ASPECT_REFINEMENTS field to return the aspects of a product. For implementation help, refer to eBay API documentation at https://developer.ebay.com/devzone/rest/api-ref/marketing/types/MarketingAspectFilter.html | [optional] 
 **limit** | **string**| This value specifies the maximum number of products to return in a result set. Note: Maximum value means the call will return up to that many products per set, but it can be less than this value. If the number of products found is less than this value, the call will return all of the products matching the criteria. Default: 8 Maximum: 100 | [optional] 

### Return type

[**BestSellingProductResponse**](BestSellingProductResponse.md)

### Authorization

[Client Credentials](../README.md#Client Credentials)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

