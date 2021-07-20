using CustomerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerUI.Services.Intefaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        bool DeleteCustomer(int id);
        Customer AddCustomer(Customer obj);
        Customer UpdateCustomer(Customer obj);
    }
}
