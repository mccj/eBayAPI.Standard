using RestSharp;
using System;
using System.Collections.Generic;

namespace Api.Client
{
    public abstract class ApiBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemApiBase"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        protected ApiBase(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemApiBase"/> class.
        /// </summary>
        /// <returns></returns>
        protected ApiBase(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }
    }

    //public class aaaaa : ApiBase
    //{
    //    /// <summary>
    //    ///  This call searches for eBay items by various URI query parameters and retrieves summaries of the items. You can search by keyword, category, eBay product ID (ePID), or GTIN or a combination of these. The following are examples of using these parameters to limit the results: The following call returns 4,330,774 items. &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?q=phone This call, which limits the results to the category &quot;Cell Phones &amp; Smartphones&quot;, returns 142,098 items. &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?q=phone&amp;category_ids=9355 These calls, which limit results to a Samsung Galaxy S5, returns 97 items. &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?q=phone&amp;category_ids=220&amp;epid=182527490 &nbsp;&nbsp;&nbsp;or &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?epid=182527490 Controlling what is returned You can also control what is returned by using the fieldgroups field. In addition to returning items, which is the default, you can return refinements (metadata) about an item that enables you to create aspect histograms. A histogram enables users to drill down in each refinement narrowing the search results. You can return: ASPECT_REFINEMENTS - Lets shoppers refine the result set by variation aspects, such as Brand, Color, etc. BUYING_OPTION_REFINEMENT - Lets shoppers refine the result set by either FIXED_PRICE or AUCTION CATEGORY_REFINEMENTS - Lets shoppers refine the result set by items in a category CONDITION_REFINEMENT - Lets shoppers refine the result set by item condition, such as NEW, USED, etc. EXTENDED - Returns the shortDescription field, which provides condition and item aspect information. MATCHING_ITEMS - The default, which returns the items. When used with one or more of the refinement values above the specified refinements and all the matching items are returned. FULL - This returns all the refinement containers and all the matching items. Filtering by aspects You can use the ASPECT_REFINEMENTS returned to filter the result set using the aspect_filter field. For example: This call gets a list of the aspects pairs for the item and the dominant category (category most of the items are in). /buy/browse/v1/item_summary/search?q=world cup soccer ball&amp;fieldgroups=ASPECT_REFINEMENTS This call filters the items by one of the aspect pairs returned and the dominant category. The category ID is required twice when using aspect_filter; once as a URI parameter and as part of the aspect_filter. /buy/browse/v1/item_summary/search?q=world cup soccer ball&amp;category_ids=20863&amp;aspect_filter=categoryId:20863,Brand:{adidas} This call filters the items by multiple aspects /buy/browse/v1/item_summary/search?q=world cup soccer ball&amp;category_ids=20863&amp;aspect_filter=categoryId:20863,Brand:{adidas},Featured Refinements:{Adidas Match Ball} This call filters the items by multiple aspect values /buy/browse/v1/item_summary/search?q=world cup soccer ball&amp;category_ids=20863&amp;aspect_filter=categoryId:20863,Brand:{Nike|Wilson} Fields filters There are also field filters you can use to refine the result set, such as listing format, item condition, price range, listing end date, location, and more. You can use multiple field filters in a single call. For a list and details of the supported filters, see search Call Field Filters. Pagination and sort controls There are pagination controls ( limit and offset fields) and sort query parameters that control/sort the data that is returned. By default, the results are sorted by &quot;Best Match&quot;. For more information about Best Match, see the eBay help page Best Match. URLs for this call Production URL: https://api.ebay.com/buy/browse/v1/item_summary/ Sandbox URL: https://api.sandbox.ebay.com/buy/browse/v1/item_summary/ Request headers You will want to use the X-EBAY-C-ENDUSERCTX request header with this call. If you are an eBay Network Partner you must use affiliateCampaignId=ePNCampaignId,affiliateReferenceId=referenceId in the header in order to be paid for selling eBay items on your site and it is strongly recommended you use contextualLocation to improve the estimated delivery window information. For details see, Request headers in the Buy APIs Overview. Restrictions This call can return a maximum of 10,000 items. For a list of supported sites and other restrictions, see API Restrictions. URL Encoding Parameters and Headers As with all query parameter values, the filter parameter value and request header values must be URL encoded. For better readability, the examples in this document omit the encoding. Example: &nbsp;&nbsp;search?q=world cup soccer ball&amp;category_ids=20863&amp;aspect_filter=categoryId:20863,Brand:{Nike|Wilson} Encoded Example: &nbsp;&nbsp; search?q=world cup soccer ball&amp;category_ids=20863&amp;aspect_filter=categoryId%3A20863%2CBrand%3A%7BNike%7CWilson%7D For more information about encoding, see HTML URL Encoding Reference.
    //    /// </summary>
    //    /// <param name="aspect_filter">This field lets you filter by item aspects. The aspect name/value pairs and category, which is required, is used to limit the results to specific aspects of the item. For example, in a clothing category one aspect pair would be Color/Red. For example, the call below uses the category ID for Women's Clothing. This will return only items for a woman's red shirt. /buy/browse/v1/item_summary/search?q=shirt&amp;category_ids=15724&amp;aspect_filter=categoryId:15724,Color:{Red} To get a list of the aspects pairs and the category, which is returned in the dominantCategoryId field, set fieldgroups to ASPECT_REFINEMENTS. /buy/browse/v1/item_summary/search?q=shirt&amp;fieldgroups=ASPECT_REFINEMENTS Required: The category ID is required twice; once as a URI parameter and as part of the aspect_filter. For implementation help, refer to eBay API documentation at https://developer.ebay.com/devzone/rest/api-ref/browse/types/AspectFilter.html</param> 
    //    /// <param name="category_ids">The category ID is used to limit the results. This field can have one category ID or a comma separated list of IDs. For example: &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?category_ids=29792 Note: Currently, you can pass in only one category ID. You can also use any combination of the category_Ids, epid, and q fields. This gives you additional control over the result set. For example, let's say you are looking of a toy phone. If you search for &quot;phone&quot;, the result set will be mobile phones because this is the &quot;Best Match&quot; for this search. But if you also include the toy category ID, the results will be what you wanted. For example: &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?q=phone&amp;category_ids=220 The list of eBay category IDs is not published and category IDs are not the same across all the eBay marketplaces. You can use the following techniques to find a category by site: Use the Category Changes page. Use the Taxonomy API. For details see Get Categories for Buy APIs. Submit the following call to get the dominantCategoryId for an item. /buy/browse/v1/item_summary/search?q=keyword&amp;fieldgroups=ASPECT_REFINEMENTS Note: If a top-level (L1) category is specified, you must also include the q query parameter. Required: The call must have category_ids, epid, gtin, or q (or any combination of these)</param> 
    //    /// <param name="epid">The ePID is the eBay product identifier of a product from the eBay product catalog. This field limits the results to only items in the specified ePID. The Marketing API getMerchandisedProducts call and the Browse API getItem, getItemByLegacyId, and getItemsByItemGroup calls return the ePID of the product. You can also use the product_summary/search call in the Catalog API to search for the ePID of the product. &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?epid=15032 Maximum: 1 Required: The call must have category_ids, epid, gtin, or q (or any combination of these)</param> 
    //    /// <param name="fieldgroups">This field is a comma separated list of values that lets you control what is returned in the response. The default is MATCHING_ITEMS, which returns the items that match the keyword or category specified. The other values return data that can be used to create histograms or provide additional information. Valid Values: ASPECT_REFINEMENTS - This returns the aspectDistributions container, which has the dominantCategoryId, matchCount, and refinementHref for the various aspects of the items found. For example, if you searched for 'Mustang', some of the aspect would be Model Year, Exterior Color, Vehicle Mileage, etc. Note: ASPECT_REFINEMENTS are category specific. BUYING_OPTION_REFINEMENTS - This returns the buyingOptionDistributions container, which has the matchCount and refinementHref for AUCTION and FIXED_PRICE (Buy It Now) items. Note: Classified items are not supported. CATEGORY_REFINEMENTS - This returns the categoryDistributions container, which has the categories that the item is in. CONDITION_REFINEMENTS - This returns the conditionDistributions container, such as NEW, USED, etc. Within these groups are multiple states of the condition. For example, New can be New without tag, New in box, New without box, etc. EXTENDED - Returns the shortDescription field, which provides condition and item aspect information. MATCHING_ITEMS - This is meant to be used with one or more of the refinement values above. You use this to return the specified refinements and all the matching items. FULL - This returns all the refinement containers and all the matching items. Code so that your app gracefully handles any future changes to this list. Default: MATCHING_ITEMS</param> 
    //    /// <param name="filter">This field supports multiple field filters that can be used to limit/customize the result set. For example: &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?q=shirt&amp;filter=price:[10..50] You can also combine filters. &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?q=shirt&amp;filter=price:[10..50],sellers:{rpseller|bigSal} The following are the supported filters. For details and examples for all the filters, see search Call Field Filters. buyingOptions conditionIds conditions deliveryCountry deliveryOptions deliveryPostalCode excludeCategoryIds excludeSellers itemEndDate itemLocationCountry itemStartDate paymentMethods pickupCountry pickupPostalCode pickupRadius pickupRadiusUnit price priceCurrency maxDeliveryCost (free shipping) returnsAccepted sellerAccountTypes sellers For implementation help, refer to eBay API documentation at https://developer.ebay.com/devzone/rest/api-ref/browse/types/FilterField.html</param> 
    //    /// <param name="gtin">This field lets you search by the Global Trade Item Number of the item as defined by http://www.gtin.info. This can be a UPC (Universal Product Code), EAN (European Article Number), or an ISBN (International Standard Book Number) value. &nbsp;&nbsp;&nbsp;/buy/browse/v1/item_summary/search?gtin=099482432621 Maximum: 1 Required: The call must have category_ids, epid, gtin, or q (or any combination of these)</param> 
    //    /// <param name="limit">The number of items in a result set. Default: 50 Maximum per result set: 200 Total Maximum number of items for all result sets: 10,000</param> 
    //    /// <param name="offset">The number of items to skip in the result set. This is used with the limit field to control the pagination of the output. If offset is 0 and limit is 10, the call will retrieve items 1-10 from the list of items returned, if offset is 10 and limit is 10, the call will retrieve items 11 thru 20 from the list of items returned. Valid Values: 0-10,000 (inclusive) Default: 0 Maximum number of items returned: 10,000</param> 
    //    /// <param name="q">A string consisting of one or more keywords that are used to search for items on eBay. The keywords are handled as follows: If the keywords are separated by a comma (iphone,ipad), the query returns items that have iphone AND ipad. If the keywords are separated by a space (iphone&nbsp;ipad or iphone,&nbsp;ipad), the query returns items that have iphone OR ipad. Restriction: The * wildcard character is not allowed in this field. Required: The call must have category_ids, epid, gtin, or q (or any combination of these)</param> 
    //    /// <param name="sort">Specifies the order and the field name to use to sort the items. To sort in descending order use - before the field name. Currently, you can only sort by price (in ascending or descending order), or by distance (only applicable if the &quot;pickup&quot; filters are used, and only ascending order is supported). If no sort parameter is submitted, the result set is sorted by &quot;Best Match&quot;. The following are examples of using the sort query parameter. Sort Result &amp;sort=price Sorts by price in ascending order (lowest price first) &amp;sort=-price Sorts by price in descending order (highest price first) &amp;sort=distance Sorts by distance in ascending order (shortest distance first) Default: ascending For implementation help, refer to eBay API documentation at https://developer.ebay.com/devzone/rest/api-ref/browse/types/SortField.html</param> 
    //    /// <returns>SearchPagedCollection</returns>
    //    public SearchPagedCollection search(string aspect_filter = null, string category_ids = null, string epid = null, string fieldgroups = null, string filter = null, string gtin = null, string limit = null, string offset = null, string q = null, string sort = null)
    //    {


    //        var path = "/item_summary/search";
    //        path = path.Replace("{format}", "json");


    //        var queryParams = new Dictionary<String, String>();
    //        var headerParams = new Dictionary<String, String>();
    //        var formParams = new Dictionary<String, String>();
    //        var fileParams = new Dictionary<String, FileParameter>();
    //        String postBody = null;

    //        if (aspect_filter != null) queryParams.Add("aspect_filter", ApiClient.ParameterToString(aspect_filter)); // query parameter
    //        if (category_ids != null) queryParams.Add("category_ids", ApiClient.ParameterToString(category_ids)); // query parameter
    //        if (epid != null) queryParams.Add("epid", ApiClient.ParameterToString(epid)); // query parameter
    //        if (fieldgroups != null) queryParams.Add("fieldgroups", ApiClient.ParameterToString(fieldgroups)); // query parameter
    //        if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
    //        if (gtin != null) queryParams.Add("gtin", ApiClient.ParameterToString(gtin)); // query parameter
    //        if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
    //        if (offset != null) queryParams.Add("offset", ApiClient.ParameterToString(offset)); // query parameter
    //        if (q != null) queryParams.Add("q", ApiClient.ParameterToString(q)); // query parameter
    //        if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

    //        // authentication setting, if any
    //        var authSettings = new String[] { "Client Credentials" };

    //        // make the HTTP request
    //        var response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

    //        if (((int)response.StatusCode) >= 400)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
    //        else if (((int)response.StatusCode) == 0)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

    //        return (SearchPagedCollection)ApiClient.Deserialize(response.Content, typeof(SearchPagedCollection), response.Headers);
    //    }
    //    /// <summary>
    //    ///  This call retrieves the details of a specific item, such as description, price, category, all item aspects, condition, return policies, seller feedback and score, shipping options, shipping costs, estimated delivery, and other information the buyer needs to make a purchasing decision. The Buy APIs are designed to let you create an eBay shopping experience in your app or website. This means you will need to know when something, such as the availability, quantity, etc., has changed in any eBay item you are offering. You can do this easily by setting the fieldgroups URI parameter. This parameter lets you control what is returned in the response. Setting fieldgroups to COMPACT reduces the response to only the five fields that you need in order to check if any item detail has changed. Setting fieldgroups to PRODUCT, adds additional fields to the default response that return information about the product of the item. You can use either COMPACT or PRODUCT but not both. For more information, see fieldgroups. URLs for this call Production URL: https://api.ebay.com/buy/browse/v1/item/ Sandbox URL: https://api.sandbox.ebay.com/buy/browse/v1/item/ Request headers You will want to use the X-EBAY-C-ENDUSERCTX request header with this call. If you are an eBay Network Partner you must use affiliateCampaignId=ePNCampaignId,affiliateReferenceId=referenceId in the header in order to be paid for selling eBay items on your site and it is strongly recommended you use contextualLocation to improve the estimated delivery window information. For details see, Request headers in the Buy APIs Overview. Restrictions For a list of supported sites and other restrictions, see API Restrictions.
    //    /// </summary>
    //    /// <param name="fieldgroups">This parameter lets you control what is returned in the response. If you do not set this field, the call returns all the details of the item. Valid values: PRODUCT - This adds the additionalImages, additionalProductIdentities, aspectGroups, description, gtins, image, and title product fields to the response, which describe the product associated with the item. See Product for more information about these fields. COMPACT - This returns only the following fields, which let you quickly check if the availability or price of the item has changed, if the item has been revised by the seller, or if an item's top-rated plus status has changed for items you have stored. itemId - The identifier of the item. sellerItemRevision - An identifier generated/incremented when a seller revises the item. There are two types of item revisions; seller changes, such as changing the title, and eBay system changes, such as changing the quantity when an item is purchased. This ID is changed only when the seller makes a change to the item. This means you cannot use this value to determine if the quantity has changed. topRatedBuyingExperience - A boolean value indicating if this item is a top-rated plus item. A change in the item's top rated plus standing is not tracked by the revision ID. See topRatedBuyingExperience for more information. price - This is tracked by the revision ID but is returned here to enable you to quickly verify the price of the item. estimatedAvailabilities - Returns the item availability information, which is based on the item's quantity. Changes in quantity are not tracked by the revision ID. For Example To check if a stored item's information is current, do following. Pass in the item ID and set fieldgroups to COMPACT. item/v1|46566502948|0?fieldgroups=COMPACT Do one of the following: If the sellerItemRevision field is returned and you haven't stored a revision number for this item, record the number and pass in the item ID in the getItem call to get the latest information. If the revision number is different from the value you have stored, update the value and pass in the item ID in the getItem call to get the latest information. If the sellerItemRevision field is not returned or has not changed, where needed, update the item information with the information returned in the response. Maximum value: 1 If more than one values is specified, the first value will be used.</param> 
    //    /// <param name="item_id">The eBay RESTful identifier of an item. This ID is returned by the Browse and Feed API calls. RESTful Item ID Format: v1|#|# For example: v1|272394640372|0 or v1|162846450672|461882996982 For more information about item ID for RESTful APIs, see the Legacy API compatibility section of the Buy APIs Overview.</param> 
    //    /// <returns>Item</returns>
    //    public Item getItem(string item_id, string fieldgroups = null)
    //    {
    //        // verify the required parameter 'item_id' is set
    //        if (item_id == null) throw new ApiException(400, "Missing required parameter 'item_id' when calling getItem");

    //        var path = "/item/{item_id}";
    //        path = path.Replace("{format}", "json");
    //        path = path.Replace("{" + "item_id" + "}", ApiClient.ParameterToString(item_id));

    //        var queryParams = new Dictionary<String, String>();
    //        var headerParams = new Dictionary<String, String>();
    //        var formParams = new Dictionary<String, String>();
    //        var fileParams = new Dictionary<String, FileParameter>();
    //        String postBody = null;

    //        if (fieldgroups != null) queryParams.Add("fieldgroups", ApiClient.ParameterToString(fieldgroups)); // query parameter

    //        // authentication setting, if any
    //        var authSettings = new String[] { "Client Credentials" };

    //        // make the HTTP request
    //        var response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

    //        if (((int)response.StatusCode) >= 400)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
    //        else if (((int)response.StatusCode) == 0)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

    //        return (Item)ApiClient.Deserialize(response.Content, typeof(Item), response.Headers);
    //    }
    //    /// <summary>
    //    ///  This call is a bridge between the eBay legacy APIs, such as Trading, Shopping, and Finding and the eBay Buy APIs. There are differences between how legacy APIs and RESTful APIs return the identifier of an &quot;item&quot;. There is also a difference in what the item ID represents and in the format of the item ID value returned. This call lets you use the legacy item IDs retrieve the details of a specific item, such as description, price, and other information the buyer needs to make a purchasing decision. It also returns the RESTful item ID, which you can use with all the Buy API calls. For more information about how to use legacy IDs with the Buy APIs, see Legacy API compatibility in the Buying Integration guide. This call returns the item details and requires you to pass in either the item ID of a non-variation item or the item IDs of both the parent and child of an item group. An item group is an item that has various aspect differences, such as color, size, storage capacity, etc. When an item group is created, one of the item variations, such as the red shirt size L, is chosen as the &quot;parent&quot;. All the other items in the group are the children, such as the blue shirt size L, red shirt size M, etc. The fieldgroups URI parameter lets you control what is returned in the response. Setting fieldgroups to PRODUCT, adds additional fields to the default response that return information about the product of the item. For more information, see fieldgroups. URLs for this call Production URL: https://api.ebay.com/buy/browse/v1/item/get_item_by_legacy_id/ Sandbox URL: https://api.sandbox.ebay.com/buy/browse/v1/item/get_item_by_legacy_id/ Request headers You will want to use the X-EBAY-C-ENDUSERCTX request header with this call. If you are an eBay Network Partner you must use affiliateCampaignId=ePNCampaignId,affiliateReferenceId=referenceId in the header in order to be paid for selling eBay items on your site and it is strongly recommended you use contextualLocation to improved the estimated delivery window information. For details see, Request headers in the Buy APIs Overview. Restrictions For a list of supported sites and other restrictions, see API Restrictions.
    //    /// </summary>
    //    /// <param name="fieldgroups">This field lets you control what is returned in the response. If you do not set this field, the call returns all the details of the item. Note: In this call, the only value supported is PRODUCT. Valid values: PRODUCT - This adds the additionalImages, additionalProductIdentities, aspectGroups, description, gtins, image, and title fields to the response, which describe the item's product. See Product for more information about these fields.</param> 
    //    /// <param name="legacy_item_id">Specifies either: The legacy item ID of an item that is not part of a group. The legacy item ID of a group, which is the ID of the &quot;parent&quot; of the group of items. Note: If you pass in a group ID, you must also use the legacy_variation_id field and pass in the legacy ID of the specific item variation (child ID). Legacy IDs are returned by eBay traditional APIs, such as the Trading API or Finding API. The following is an example of using the value of the ItemID field for a specific item from Trading to get the RESTful itemId value. &nbsp;&nbsp;&nbsp; browse/v1/item/get_item_by_legacy_id?legacy_item_id=110039490209 Maximum: 1</param> 
    //    /// <param name="legacy_variation_id">Specifies the legacy item ID of a specific item in an item group, such as the red shirt size L. Legacy IDs are returned by eBay traditional APIs, such as the Trading API or Finding API. Maximum: 1 Requirement: You must always pass in the legacy_item_id with the legacy_variation_id</param> 
    //    /// <param name="legacy_variation_sku">Specifics the legacy SKU of the item. SKU are item IDs created by the seller. Legacy SKUs are returned by eBay traditional APIs, such as the Trading API or Finding API. The following is an example of using the value of the ItemID and SKU fields, which were returned by the Trading API, to get the RESTful itemId value. &nbsp;&nbsp;&nbsp; browse/v1/item/get_item_by_legacy_id?legacy_item_id=110039490209&amp;legacy_variation_sku=V-00031-WHM Maximum: 1 Requirement: You must always pass in the legacy_item_id with the legacy_variation_sku</param> 
    //    /// <returns>Item</returns>
    //    public Item getItemByLegacyId(string legacy_item_id, string fieldgroups = null, string legacy_variation_id = null, string legacy_variation_sku = null)
    //    {
    //        // verify the required parameter 'legacy_item_id' is set
    //        if (legacy_item_id == null) throw new ApiException(400, "Missing required parameter 'legacy_item_id' when calling getItemByLegacyId");

    //        var path = "/item/get_item_by_legacy_id";
    //        path = path.Replace("{format}", "json");


    //        var queryParams = new Dictionary<String, String>();
    //        var headerParams = new Dictionary<String, String>();
    //        var formParams = new Dictionary<String, String>();
    //        var fileParams = new Dictionary<String, FileParameter>();
    //        String postBody = null;

    //        if (fieldgroups != null) queryParams.Add("fieldgroups", ApiClient.ParameterToString(fieldgroups)); // query parameter
    //        if (legacy_item_id != null) queryParams.Add("legacy_item_id", ApiClient.ParameterToString(legacy_item_id)); // query parameter
    //        if (legacy_variation_id != null) queryParams.Add("legacy_variation_id", ApiClient.ParameterToString(legacy_variation_id)); // query parameter
    //        if (legacy_variation_sku != null) queryParams.Add("legacy_variation_sku", ApiClient.ParameterToString(legacy_variation_sku)); // query parameter

    //        // authentication setting, if any
    //        var authSettings = new String[] { "Client Credentials" };

    //        // make the HTTP request
    //        var response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

    //        if (((int)response.StatusCode) >= 400)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
    //        else if (((int)response.StatusCode) == 0)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

    //        return (Item)ApiClient.Deserialize(response.Content, typeof(Item), response.Headers);
    //    }
    //    /// <summary>
    //    ///  This call retrieves the details of the individual items in an item group. An item group is an item that has various aspect differences, such as color, size, storage capacity, etc. You pass in the item group ID as a URI parameter. You use this call to show the item details of items with multiple aspects, such as color, size, storage capacity, etc. This call returns two main containers; items and commonDescriptions. The items container has an array of containers with the details of each item in the group. The commonDescriptions container has an array of containers for a description and the item IDs of all the items that have this exact description. Because items within an item group often have the same description, this decreases the size of the response. URLs for this call Production URL: https://api.ebay.com/buy/browse/v1/item/get_items_by_item_group/ Sandbox URL: https://api.sandbox.ebay.com/buy/browse/v1/item/get_items_by_item_group/ Request headers You will want to use the X-EBAY-C-ENDUSERCTX request header with this call. If you are an eBay Network Partner you must use affiliateCampaignId=ePNCampaignId,affiliateReferenceId=referenceId in the header in order to be paid for selling eBay items on your site and it is strongly recommended you use contextualLocation to improved the estimated delivery window information. For details see, Request headers in the Buy APIs Overview. Restrictions For a list of supported sites and other restrictions, see API Restrictions.
    //    /// </summary>
    //    /// <param name="item_group_id">Identifier of the item group to return. An item group is an item that has various aspect differences, such as color, size, storage capacity, etc. This ID is returned in the itemGroupHref field of the search and getItem calls. For Example: https://api.ebay.com/buy/browse/v1/item/get_items_by_item_group?item_group_id=351825690866</param> 
    //    /// <returns>Items</returns>
    //    public Items getItemsByItemGroup(string item_group_id)
    //    {
    //        // verify the required parameter 'item_group_id' is set
    //        if (item_group_id == null) throw new ApiException(400, "Missing required parameter 'item_group_id' when calling getItemsByItemGroup");

    //        var path = "/item/get_items_by_item_group";
    //        path = path.Replace("{format}", "json");


    //        var queryParams = new Dictionary<String, String>();
    //        var headerParams = new Dictionary<String, String>();
    //        var formParams = new Dictionary<String, String>();
    //        var fileParams = new Dictionary<String, FileParameter>();
    //        String postBody = null;

    //        if (item_group_id != null) queryParams.Add("item_group_id", ApiClient.ParameterToString(item_group_id)); // query parameter

    //        // authentication setting, if any
    //        var authSettings = new String[] { "Client Credentials" };

    //        // make the HTTP request
    //        var response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

    //        if (((int)response.StatusCode) >= 400)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.Content, response.Content);
    //        else if (((int)response.StatusCode) == 0)
    //            throw new ApiException((int)response.StatusCode, "Error calling GetItem: " + response.ErrorMessage, response.ErrorMessage);

    //        return (Items)ApiClient.Deserialize(response.Content, typeof(Items), response.Headers);
    //    }
    //}
}