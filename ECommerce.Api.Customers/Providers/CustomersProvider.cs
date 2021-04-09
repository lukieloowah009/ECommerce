using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {

        private readonly CustomersDbContext _dbContext;
        private readonly ILogger<CustomersProvider> _logger;
        private readonly IMapper _mapper;

        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }

        

        public async Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string errorMessage)> getCustomersAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            try
            {
                if(customers != null && customers.Any())
                {
                    var result = _mapper.Map<IEnumerable<Db.Customer>, IEnumerable<Models.Customer>>(customers);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
                
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Customer Customer, string errorMessage)> getCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.Id == id);
            try
            {
                if (customer != null)
                {
                    var result = _mapper.Map<Db.Customer, Models.Customer>(customer);
                    return (true, result, null);
                }
                return (false, null, "Not Found");

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        private void SeedData()
        {
            if(!_dbContext.Customers.Any())
            {
                _dbContext.Add(new Db.Customer { Id = 1, Name = "Luke", Address = "3301 SW 13th Street, Gainesville, Florida" });
                _dbContext.Add(new Db.Customer { Id = 2, Name = "John", Address = "2236, Murphree Hall, Gainesville, Florida" });
                _dbContext.Add(new Db.Customer { Id = 3, Name = "Matthew", Address = "1128, SW Archer Road, Gainesville, Florida" });
                _dbContext.Add(new Db.Customer { Id = 4, Name = "Mark", Address = "2276, University Road, Gainesville, Florida" });
                _dbContext.SaveChanges();
            }
            
        }
    }
}
