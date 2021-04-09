using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext _dbContext;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper )
        {
            this._dbContext = dbContext;
            this._logger = logger;
            this._mapper = mapper;

            SeedData();
        }

        public async Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    var result = _mapper.Map<Db.Products, Models.Product>(product);
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

        public async Task<(bool IsSuccess, IEnumerable<Product> Products,
            string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<Db.Products>, IEnumerable<Models.Product>>(products);
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

            if(!_dbContext.Products.Any())
            {
                _dbContext.Products.Add(new Db.Products() { Id = 1, Name = "Keyboard", Price = 5, Inventory = 100 });
                _dbContext.Products.Add(new Db.Products() { Id = 2, Name = "Mouse", Price = 20, Inventory = 100 });
                _dbContext.Products.Add(new Db.Products() { Id = 3, Name = "Monitor", Price = 150, Inventory = 100 });
                _dbContext.Products.Add(new Db.Products() { Id = 4, Name = "CPU", Price = 200, Inventory = 100 });
                _dbContext.SaveChanges();
            }
        }

      
    }
}
