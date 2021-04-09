﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Api.Customers.Models;

namespace ECommerce.Api.Customers.Interfaces
{
    public interface ICustomersProvider
    {

        public Task<(bool IsSuccess, IEnumerable<Customer> Customers, string errorMessage)> getCustomersAsync();

        public Task<(bool IsSuccess, Customer Customer, string errorMessage)> getCustomerAsync(int id);
    }
}
