

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");

            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .IsUnicode();

            builder.Property(p => p.Picture)
                .IsRequired(false)
                .IsUnicode();

            builder.Property(p => p.Tags)
                .IsRequired(false)
                .IsUnicode();


            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 0);

            builder.HasOne(d => d.Category)
                .WithMany(w => w.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);  

            builder.HasIndex(d => d.Name).IsUnique();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Description = "",
                Name = "samsung A 50",
                Price = 15_000_000
            });

            builder.HasData(new Product
            {
                Id = 2,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Description = "",
                Name = "samsung A 55",
                Price = 12_000_000
            });

            builder.HasData(new Product
            {
                Id = 3,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Description = "",
                Name = "xiaomi red me 1" ,
                Price = 17_500_000
            });

            builder.HasData(new Product
            {
                Id = 4,
                CategoryId = 2,
                CreatedDate = DateTime.Now,
                Description = "",
                Name = "ipad pro",
                Price = 48_000_000
            });
        }
    }
}
