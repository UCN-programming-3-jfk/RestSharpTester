using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //a list of customers which we make static to save them on the class
        //and make them persistent between calls to the controller
        //this is to simulate a storage medium like a database
        private static List<CustomerDto> customers = new List<CustomerDto>() { new CustomerDto() { Id = 1, Name = "Anna", Email = "Anna@gmail.com" }, new CustomerDto() { Id = 2, Name = "Bob", Email = "Bob@gmail.com" }, new CustomerDto() { Id = 3, Name = "Clara", Email = "Clara@gmail.com" }
    };
    [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto?> Get(int id)
        {
            CustomerDto? customer = customers.FirstOrDefault(customer => customer.Id == id);
            if(customer == null) { return NotFound(); }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CustomerDto customer)
        {
            customers.Add(customer);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerDto updateCustomer)
        {
            CustomerDto? customer = customers.FirstOrDefault(customer => customer.Id == updateCustomer.Id);
            if(customer == null) { return NotFound();}
            customer.Name = updateCustomer.Name;
            customer.Email = updateCustomer.Email;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(customers.RemoveAll(customer => customer.Id == id) > 0) { return Ok(); }
            return NotFound();
        }
    }
}