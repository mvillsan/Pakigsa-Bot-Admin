using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Server.DataAccess;
using Admin.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Admin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();

        [HttpGet]
        public Task<List<Customer>> Get()
        {
            return objCustomer.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public Task<Customer> Get(string id)
        {
            return objCustomer.GetCustomerData(id);
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            objCustomer.AddCustomer(customer);
        }

        [HttpPut]
        public void Put([FromBody] Customer customer)
        {
            objCustomer.UpdateCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objCustomer.DeleteCustomer(id);
        }
    }
}
