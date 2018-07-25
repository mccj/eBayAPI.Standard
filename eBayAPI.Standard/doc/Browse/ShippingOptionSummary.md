# IO.Swagger.Model.ShippingOptionSummary
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MaxEstimatedDeliveryDate** | **string** | The end date of the delivery window (latest projected delivery date). This value is returned in UTC format (yyyy-MM-ddThh:mm:ss.sssZ), which you can convert into the local time of the buyer. Note: For the best accuracy, always include the contextualLocation values in the X-EBAY-C-ENDUSERCTX request header. | [optional] 
**MinEstimatedDeliveryDate** | **string** | The start date of the delivery window (earliest projected delivery date). This value is returned in UTC format (yyyy-MM-ddThh:mm:ss.sssZ), which you can convert into the local time of the buyer. Note: For the best accuracy, always include the contextualLocation values in the X-EBAY-C-ENDUSERCTX request header. | [optional] 
**ShippingCost** | [**ConvertedAmount**](ConvertedAmount.md) |  | [optional] 
**ShippingCostType** | **string** | This field indicates the type of shipping used to ship the item. Possible values are FIXED (flat-rate shipping) and CALCULATED (calculated shipping). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

