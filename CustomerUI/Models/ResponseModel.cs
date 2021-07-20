using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerUI.Models
{
    public class HttpResponseModel
    {
        public string ResponseBody { get; set; }
        public int ResponseCode { get; set; }
        public bool IsSuccess { get; set; }
        public IDictionary<string, IEnumerable<string>> ResponseHeaders { get; set; }
        public string ResponseType { get; set; }
    }
    public class HttpRequestModel
    {
        public Uri FullServiceUrl { get; set; }
        public string HttpBody { get; set; }
        public IDictionary<string, string> HttpHeaders { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public string MediaType { get; set; }
    }
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

    }
}
