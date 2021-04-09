﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Api.Products.Models;

namespace ECommerce.Api.Products.Interfaces
{
    public interface IProductsProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();

        public Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id);


    }
}
