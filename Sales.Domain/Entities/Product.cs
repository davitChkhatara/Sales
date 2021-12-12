using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal QtyOnHand { get; set; }

        public long ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
