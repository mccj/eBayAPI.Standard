# IO.Swagger.Model.ConvertedAmount
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConvertedFromCurrency** | **string** | A three-letter ISO 4217 code that indicates the currency of the amount in the convertedFromValue field. This value is required or returned only if currency conversion/localization is required, and represents the pre-conversion currency. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/browse/types/CurrencyCodeEnum.html&#39;&gt;eBay API documentation&lt;/a&gt; | [optional] 
**ConvertedFromValue** | **string** | The monetary amount before any conversion is performed, in the currency specified by the convertedFromCurrency field. This value is required or returned only if currency conversion/localization is required. The value field contains the converted amount of this value, in the currency specified by the currency field. | [optional] 
**Currency** | **string** | A three-letter ISO 4217 code that indicates the currency of the amount in the value field. If currency conversion/localization is required, this is the post-conversion currency of the amount in the value field. Default: The currency of the authenticated user&#39;s country. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/browse/types/CurrencyCodeEnum.html&#39;&gt;eBay API documentation&lt;/a&gt; | [optional] 
**Value** | **string** | The monetary amount, in the currency specified by the currency field. If currency conversion/localization is required, this value is the converted amount, and the convertedFromValue field contains the amount in the original currency. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

