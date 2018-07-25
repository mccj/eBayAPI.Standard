# IO.Swagger.Model.Error
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Category** | **string** | This string value indicates the error category. There are three categories of errors: request errors, application errors, and system errors. | [optional] 
**Domain** | **string** | The name of the primary system where the error occurred. This is relevant for application errors. | [optional] 
**ErrorId** | **int?** | A unique code that identifies the particular error or warning that occurred. Your application can use error codes as identifiers in your customized error-handling algorithms. | [optional] 
**InputRefIds** | **List&lt;string&gt;** | An array of reference Ids that identify the specific request elements most closely associated to the error or warning, if any. | [optional] 
**LongMessage** | **string** | A detailed description of the condition that caused the error or warning, and information on what to do to correct the problem. | [optional] 
**Message** | **string** | A description of the condition that caused the error or warning. | [optional] 
**OutputRefIds** | **List&lt;string&gt;** | An array of reference Ids that identify the specific response elements most closely associated to the error or warning, if any. | [optional] 
**Parameters** | [**List&lt;ErrorParameter&gt;**](ErrorParameter.md) | An array of warning and error messages that return one or more variables contextual information about the error or warning. This is often the field or value that triggered the error or warning. | [optional] 
**Subdomain** | **string** | The name of the subdomain in which the error or warning occurred. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

