using CarWashSystemAPI.Interface;
using CarWashSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWashSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _ICustomers;

        public CustomerController(ICustomer ICustomers)
        {
            _ICustomers = ICustomers;
        }

        // GET: api/designers>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await Task.FromResult(_ICustomers.GetCustomer());
        }

        // GET api/designer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customers = await Task.FromResult(_ICustomers.GetCustomer(id));
            if (customers == null)
            {
                return NotFound();
            }
            return customers;
        }

        // POST api/designer
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            _ICustomers.AddCustomer(customer);
            return await Task.FromResult(customer);
        }

        // PUT api/designer/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            try
            {
                _ICustomers.UpdateCustomer(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(customer);
        }

        // DELETE api/designer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var customers = _ICustomers.DeleteCustomer(id);
            return await Task.FromResult(customers);
        }
        private bool CustomerExists(int id)
        {
            return _ICustomers.CheckCustomer(id);
        }
    }
}
