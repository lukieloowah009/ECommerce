using System;
namespace ECommerce.Api.Products.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Db.Products, Models.Product>();
        }
    }
}
