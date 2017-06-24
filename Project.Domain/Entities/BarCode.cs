using System;

namespace Project.Domain.Entities
{
    public class Barcode : BaseEntity<long>
    {
        public String Code { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
