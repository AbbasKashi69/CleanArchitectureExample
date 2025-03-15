

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo");

            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.HasOne(d=> d.Parent)
                .WithMany(w=> w.Children)
                .HasForeignKey(d => d.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(d => new { d.ParentId, d.Name }).IsUnique();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "لوازم اکترونیک",
                    ParentId = null
                });

            builder.HasData(
                new Category
                {
                    Id = 2,
                    Name = "موبایل",
                    ParentId = 1
                });

            builder.HasData(
                new Category
                {
                    Id = 3,
                    Name = "لوازم موبایل",
                    ParentId = 1
                });

            builder.HasData(
                new Category
                {
                    Id = 100,
                    Name = "لوازم خانگی",
                    ParentId = null
                });

            builder.HasData(
                new Category
                {
                    Id = 1000,
                    Name = "لوازم یدکی ماشین",
                    ParentId = null
                });
        }
    }
}
