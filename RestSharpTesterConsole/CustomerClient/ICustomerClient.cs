using RestSharpTesterConsole.CustomerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTesterConsole.CustomerClient
{
    public interface ICustomerClient
    {
        IEnumerable<CustomerDto>? GetCustomers();
        CustomerDto? GetCustomerById(int id);
        void DeleteCustomer(int id);
        void UpdateCustomer(CustomerDto customer);
        void InsertCustomer(CustomerDto customer);
    }
}