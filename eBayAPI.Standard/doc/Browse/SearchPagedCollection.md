# IO.Swagger.Model.SearchPagedCollection
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Href** | **string** | The URI of the current result set. For example: https://api.ebay.com/buy/v1/item/search?q&#x3D;shirt&amp;amp;price&#x3D;[20..80]&amp;amp;limit&#x3D;5 This query is for a shirt, that is priced between 20 and 80 dollars and limits the response to 5 items. | [optional] 
**ItemSummaries** | [**List&lt;ItemSummary&gt;**](ItemSummary.md) | An array of items in one result set. The items are sorted according to the sorting method specified in the request. | [optional] 
**Limit** | **int?** | The maximum number of items that can be returned in a result set. This is the limit value that was used in the request. | [optional] 
**Next** | **string** | The URL for the next result set. This is returned if there is a next result set. The following example returns items 11 thru 20 from the list of items. https://api.ebay.com/buy/v1/item/search?query&#x3D;t-shirts&amp;amp;limit&#x3D;10&amp;amp;offset&#x3D;0 | [optional] 
**Offset** | **int?** | This value indicates the current &#39;page&#39; of items being displayed. This value is 0 for the first page of data, 1 for the second page of data, and so on. | [optional] 
**Prev** | **string** | The URL for the previous result set. This is returned if there is a previous result set. The following example returns items 1 thru 10 from the list of items. https://api.ebay.com/buy/v1/item/search?query&#x3D;t-shirts&amp;amp;limit&#x3D;10&amp;amp;offset&#x3D;0 | [optional] 
**Refinement** | [**Refinement**](Refinement.md) |  | [optional] 
**Total** | **int?** | The total number of items that match the input criteria. | [optional] 
**Warnings** | [**List&lt;Error&gt;**](Error.md) | The container with all the warnings for the input request. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

