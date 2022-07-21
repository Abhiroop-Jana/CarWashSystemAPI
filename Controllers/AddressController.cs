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
    public class AddressController : ControllerBase
    {
        private readonly IAddress _IAddresses;

        public AddressController(IAddress IAddresses)
        {
            _IAddresses = IAddresses;
        }

        // GET: api/address>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            return await Task.FromResult(_IAddresses.GetAddress());
        }

        // GET api/address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var addresses = await Task.FromResult(_IAddresses.GetAddress(id));
            if (addresses == null)
            {
                return NotFound();
            }
            return addresses;
        }

        // POST api/address
        [HttpPost]
        public async Task<ActionResult<Address>> Post(Address address)
        {
            _IAddresses.AddAddress(address);
            return await Task.FromResult(address);
        }

        // PUT api/address/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> Put(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }
            try
            {
                _IAddresses.UpdateAddress(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(address);
        }

        // DELETE api/address/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> Delete(int id)
        {
            var addresses = _IAddresses.DeleteAddress(id);
            return await Task.FromResult(addresses);
        }
        private bool AddressExists(int id)
        {
            return _IAddresses.CheckAddress(id);
        }
    }
}