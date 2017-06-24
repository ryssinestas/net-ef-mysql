using System;

namespace Project.Domain.Entities
{
    public class Product : BaseEntity<long>
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
    }
}
