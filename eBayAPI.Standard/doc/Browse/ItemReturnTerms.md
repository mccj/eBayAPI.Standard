# IO.Swagger.Model.ItemReturnTerms
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExtendedHolidayReturnsOffered** | **bool?** | Indicates if the seller has enabled the Extended Holiday Returns feature on the item. Extended Holiday Returns are only applicable during the US holiday season, and gives buyers extra time to return an item. This &#39;extra time&#39; will typically extend beyond what is set through the returnPeriod value. | [optional] 
**RefundMethod** | **string** | An enumeration value that indicates how a buyer is refunded when an item is returned. Code so that your app gracefully handles any future changes to this list. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/browse/types/RefundMethodEnum.html&#39;&gt;eBay API documentation&lt;/a&gt; | [optional] 
**RestockingFeePercentage** | **string** | This string field indicates the restocking fee percentage that the seller has set on the item. Sellers have the option of setting no restocking fee for an item, or they can set the percentage to 10, 15, or 20 percent. So, if the cost of the item was $100, and the restocking percentage was 20 percent, the buyer would be charged $20 to return that item, so instead of receiving a $100 refund, they would receive $80 due to the restocking fee. | [optional] 
**ReturnInstructions** | **string** | Text written by the seller describing what the buyer needs to do in order to return the item. | [optional] 
**ReturnMethod** | **string** | An enumeration value that indicates the alternative methods for a full refund when an item is returned. This field is returned if the seller offers the buyer an item replacement or exchange instead of a monetary refund. Code so that your app gracefully handles any future changes to this list. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/browse/types/ReturnMethodEnum.html&#39;&gt;eBay API documentation&lt;/a&gt; | [optional] 
**ReturnPeriod** | [**TimeDuration**](TimeDuration.md) |  | [optional] 
**ReturnsAccepted** | **bool?** | Indicates whether the seller accepts returns for the item. | [optional] 
**ReturnShippingCostPayer** | **string** | This enumeration value indicates whether the buyer or seller is responsible for return shipping costs when an item is returned. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/browse/types/ReturnShippingCostPayerEnum.html&#39;&gt;eBay API documentation&lt;/a&gt; | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

