using RestSharp;
using RestSharpTesterConsole.CustomerClient.Model;

namespace RestSharpTesterConsole.CustomerClient
{
    /// <summary>
    /// This class implements the ICustomerClient and allows for CRUD on a REST service
    /// which is located at the URL provided in the constructor
    /// NOTE: this class hasn't implemented checks for errors in communication
    /// </summary>
    public class CustomerRestClient : ICustomerClient
    {
        RestClient _client;

        public CustomerRestClient(string restUrl)
        {
            //instantiates and saves the RestSharp client
            //for use in the CRUD methods
            _client = new RestClient(restUrl);
        }
        public void DeleteCustomer(int id)
        {
            //sends a DELETE request to "api/customers/{id}"
            var request = new RestRequest($"{id}", Method.Delete);
            _client.Delete<CustomerDto>(request);
        }

        public CustomerDto? GetCustomerById(int id)
        {
            //sends a GET request to "api/customers/{id}"
            var request = new RestRequest($"{id}");
            return _client.Get<CustomerDto>(request);
        }

        public IEnumerable<CustomerDto>? GetCustomers()
        {
            //sends a GET request to "api/customers"
            return _client.Get<IEnumerable<CustomerDto>>(new RestRequest());
        }

        public void InsertCustomer(CustomerDto customer)
        {
            //sends a POST request to "api/customers"
            //with the Customer as a JSON object in body
            var request = new RestRequest("", Method.Post);
            request.AddBody(customer);
            _client.Post<CustomerDto>(request);
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            //sends a PUT request to "api/customers"
            //with the Customer as a JSON object in body
            var request = new RestRequest($"{customer.Id}");
            request.AddBody(customer);
            _client.Put<CustomerDto>(request);
        }
    }
}
