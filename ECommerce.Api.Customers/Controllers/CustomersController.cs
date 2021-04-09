using System;
using System.Threading.Tasks;
using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider _customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> getCustomers()
        {
            var result = await _customersProvider.getCustomersAsync();

            if(result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCustomer(int id)
        {
            var result = await _customersProvider.getCustomerAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
