# IO.Swagger.Api.AppsApi

All URIs are relative to *https://beatcracker.github.io/toptout/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApplicationId**](AppsApi.md#getapplicationid) | **GET** /id/ | Returns a list of all supported application ids
[**GetCategoryId**](AppsApi.md#getcategoryid) | **GET** /category/ | Returns a list of all supported application categories

<a name="getapplicationid"></a>
# **GetApplicationId**
> List<string> GetApplicationId ()

Returns a list of all supported application ids

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetApplicationIdExample
    {
        public void main()
        {
            var apiInstance = new AppsApi();

            try
            {
                // Returns a list of all supported application ids
                List&lt;string&gt; result = apiInstance.GetApplicationId();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppsApi.GetApplicationId: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getcategoryid"></a>
# **GetCategoryId**
> List<string> GetCategoryId ()

Returns a list of all supported application categories

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetCategoryIdExample
    {
        public void main()
        {
            var apiInstance = new AppsApi();

            try
            {
                // Returns a list of all supported application categories
                List&lt;string&gt; result = apiInstance.GetCategoryId();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppsApi.GetCategoryId: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
