using System.Data.Entity.ModelConfiguration;
using Project.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Mappings
{
    class BarcodeMapping : EntityTypeConfiguration<Barcode>, IMapping
    {
        public BarcodeMapping()
        {
            this.ToTable("barcodes");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("barcode_id")

                //Não precisaria dessa notação já que você não está usando a criação automática de tabelas. (Por hora deixe assim caso no futuro você mude de ideia)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("barcode_code");

            this.Property(x => x.ProductId)
                .IsRequired().
                HasColumnName("product_id");
        }
    }
}

// Relacionamentos EF
// https://msdn.microsoft.com/en-us/library/jj591620(v=vs.113).aspx
// http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx