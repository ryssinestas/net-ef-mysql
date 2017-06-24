using System.Data.Entity.ModelConfiguration;
using Project.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Mappings
{
    class ProductMapping : EntityTypeConfiguration<Product>, IMapping
    {
        public ProductMapping()
        {
            this.ToTable("products");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("product_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("product_name");

            this.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("product_description");

            this.Property(x => x.Price)
                .IsRequired().
                HasColumnName("product_price");

            this.HasMany(u => u.BarCodeList)
                .WithRequired()
                .HasForeignKey(h => h.ProductId);
        }
    }
}
