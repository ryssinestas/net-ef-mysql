using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Product : BaseEntity<long>
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public virtual ICollection<Barcode> BarCodeList { get; set; }
    }
}
