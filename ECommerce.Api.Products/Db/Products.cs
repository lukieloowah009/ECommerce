﻿using System;
namespace ECommerce.Api.Products.Db
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Inventory { get; set; }
    }
}
