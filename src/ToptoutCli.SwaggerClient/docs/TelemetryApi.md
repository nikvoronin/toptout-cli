# IO.Swagger.Api.TelemetryApi

All URIs are relative to *https://beatcracker.github.io/toptout/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetTelemetry**](TelemetryApi.md#gettelemetry) | **GET** /telemetry/ | Returns telemetry details for all known application ids
[**GetTelemetryByCategory**](TelemetryApi.md#gettelemetrybycategory) | **GET** /telemetry/category/{category}/ | Returns telemetry details for applications in specific category
[**GetTelemetryById**](TelemetryApi.md#gettelemetrybyid) | **GET** /telemetry/id/{id}/ | Returns telemetry details for specific application id

<a name="gettelemetry"></a>
# **GetTelemetry**
> List<Toptout> GetTelemetry ()

Returns telemetry details for all known application ids

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTelemetryExample
    {
        public void main()
        {
            var apiInstance = new TelemetryApi();

            try
            {
                // Returns telemetry details for all known application ids
                List&lt;Toptout&gt; result = apiInstance.GetTelemetry();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TelemetryApi.GetTelemetry: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Toptout>**](Toptout.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettelemetrybycategory"></a>
# **GetTelemetryByCategory**
> List<Toptout> GetTelemetryByCategory (string category)

Returns telemetry details for applications in specific category

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTelemetryByCategoryExample
    {
        public void main()
        {
            var apiInstance = new TelemetryApi();
            var category = category_example;  // string | 

            try
            {
                // Returns telemetry details for applications in specific category
                List&lt;Toptout&gt; result = apiInstance.GetTelemetryByCategory(category);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TelemetryApi.GetTelemetryByCategory: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **category** | **string**|  | 

### Return type

[**List<Toptout>**](Toptout.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettelemetrybyid"></a>
# **GetTelemetryById**
> Toptout GetTelemetryById (string id)

Returns telemetry details for specific application id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTelemetryByIdExample
    {
        public void main()
        {
            var apiInstance = new TelemetryApi();
            var id = id_example;  // string | 

            try
            {
                // Returns telemetry details for specific application id
                Toptout result = apiInstance.GetTelemetryById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TelemetryApi.GetTelemetryById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**Toptout**](Toptout.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
