using CustomerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerUI.Services.Intefaces
{
   public  interface IHttpHelperProvider
    {
        Task<HttpResponseModel> ExecuteHttpRequest(HttpRequestModel request);
    }
}
