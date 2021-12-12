using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class ProductType
    {
        public long Id { get; set; }

        public string TypeCode { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
