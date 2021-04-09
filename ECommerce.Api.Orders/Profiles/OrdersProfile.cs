using System;
using AutoMapper;

namespace ECommerce.Api.Orders.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile() 
        {

            CreateMap<Db.Order, Models.Order>();
            CreateMap<Db.OrderItem, Models.OrderItem>();
        }
    }
}
