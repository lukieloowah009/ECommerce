using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string errorMessage)> GetOrdersAsync(int customerId);
    }
    
}
