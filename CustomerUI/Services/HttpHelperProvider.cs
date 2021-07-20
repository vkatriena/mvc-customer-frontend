using CustomerUI.Models;
using CustomerUI.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerUI.Services
{
    public class HttpHelperProvider : IHttpHelperProvider
    {
        public async Task<HttpResponseModel> ExecuteHttpRequest(HttpRequestModel request)
        {
            var client = new HttpClient();
            var requestResponse = new HttpResponseModel();

            var httpRequest = new HttpRequestMessage
            {
                RequestUri = request.FullServiceUrl,
                Method = request.HttpMethod,
            };

            //Add Body only for non-Get Calls.
            if (!string.IsNullOrWhiteSpace(request.HttpBody) && request.HttpMethod != HttpMethod.Get)
            {
                httpRequest.Content = new StringContent(request.HttpBody, Encoding.UTF8, request.MediaType);
            }

            //Add Headers
            //httpRequest.Headers.Add("Authorization", await GetAuthToken());
            if (request.HttpHeaders?.Count > 0)
            {
                foreach (var header in request.HttpHeaders)
                    httpRequest.Headers.Add(header.Key, header.Value);
            }
            try
            {
                var httpResponse = await client.SendAsync(httpRequest);

                requestResponse.ResponseCode = (int)httpResponse.StatusCode;
                requestResponse.ResponseBody = await httpResponse.Content?.ReadAsStringAsync();
                requestResponse.ResponseHeaders = httpResponse.Headers?.ToDictionary(p => p.Key, p => p.Value);
                requestResponse.IsSuccess = httpResponse.IsSuccessStatusCode;
                requestResponse.ResponseType = httpResponse.Headers?.FirstOrDefault(p => p.Key == "Content-Type").Value?.FirstOrDefault();

            }
            catch (Exception ex)
            {
                requestResponse.ResponseCode = -1;
                requestResponse.ResponseBody = ex?.ToString();
                requestResponse.IsSuccess = false;
            }
            return requestResponse;
        }
    }
}
