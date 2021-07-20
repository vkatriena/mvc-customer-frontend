using CustomerUI.Models;
using CustomerUI.Services.Intefaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;

namespace CustomerUI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _config;
        private readonly IHttpHelperProvider _httpProvider;
        public CustomerService(IConfiguration config, IHttpHelperProvider httpProvider)
        {
            _config = config;
            _httpProvider = httpProvider;

        }
        private string BaseURL
        {
            get
            {
                return _config.GetSection("ConnectionStrings")["BaseUrl"];

            }
        }
        public Customer AddCustomer(Customer obj)
        {
           // string customerString = JsonConvert.SerializeObject(obj);
           var result = new Customer();
            var httpRequest = new HttpRequestModel
            {
                FullServiceUrl = new Uri($"{BaseURL}api/Customer/customers"),
                HttpMethod = HttpMethod.Post,
                MediaType = "application/json",
                HttpBody = JsonConvert.SerializeObject(obj)
              
            };
            var response = _httpProvider.ExecuteHttpRequest(httpRequest).Result;
            if (response.IsSuccess)
            {
                dynamic typedResponse = JsonConvert.DeserializeObject(response.ResponseBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var data = typedResponse.data;
                result = JsonConvert.DeserializeObject<Customer>(data.ToString());
            }
            return result;
        }

        public bool DeleteCustomer(int id)
        {
            //Customer result = new Customer();
            bool result = false;
            var httpRequest = new HttpRequestModel
            {
                FullServiceUrl = new Uri($"{BaseURL}api/Customer/customers/{id}"),
                HttpMethod = HttpMethod.Delete,
                MediaType = "application/json"
            };
            var response = _httpProvider.ExecuteHttpRequest(httpRequest).Result;
            if (response.IsSuccess)
            {
                dynamic typedResponse = JsonConvert.DeserializeObject(response.ResponseBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var data = typedResponse.data;
                result = data;
            }
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            Customer result = new Customer();
            var httpRequest = new HttpRequestModel
            {
                FullServiceUrl = new Uri($"{BaseURL}api/Customer/customers/{id}"),
                HttpMethod = HttpMethod.Get,
                MediaType = "application/json"
            };
            var response = _httpProvider.ExecuteHttpRequest(httpRequest).Result;
            if (response.IsSuccess)
            {
                dynamic typedResponse = JsonConvert.DeserializeObject(response.ResponseBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var data = typedResponse.data;
                result = JsonConvert.DeserializeObject<Customer>(data.ToString());
            }

            return result;
        }

        public List<Customer> GetCustomers()
        {
            //string myurl = BaseURL;
            List<Customer> result = new List<Customer>();
            var httpRequest = new HttpRequestModel
            {
                FullServiceUrl = new Uri($"{BaseURL}api/Customer/customers"),                
                HttpMethod = HttpMethod.Get,
                MediaType = "application/json"
            };
            var response =  _httpProvider.ExecuteHttpRequest(httpRequest).Result;

            if (response.IsSuccess)
            {               
                dynamic typedResponse = JsonConvert.DeserializeObject(response.ResponseBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var data = typedResponse.data;
                result = JsonConvert.DeserializeObject<List<Customer>>(data.ToString());                
            }
           
            return result;
        }

        public Customer UpdateCustomer(Customer obj)
        {
            var result = obj;
            var httpRequest = new HttpRequestModel
            {
                FullServiceUrl = new Uri($"{BaseURL}api/Customer/customers"),
                HttpMethod = HttpMethod.Put,
                MediaType = "application/json",
                HttpBody = JsonConvert.SerializeObject(obj)
            };
            var response = _httpProvider.ExecuteHttpRequest(httpRequest).Result;
            if (response.IsSuccess)
            {
                dynamic typedResponse = JsonConvert.DeserializeObject(response.ResponseBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var data = typedResponse.data;
                result = JsonConvert.DeserializeObject<Customer>(data.ToString());
            }

            return result;
        }
    }
}
