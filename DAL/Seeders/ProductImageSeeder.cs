using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders
{
    public class ProductImageSeeder : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(
                new
                {
                    Id = 1,
                    ImageUrl = "/images/products/asus-rog-strix-g15-1.jpg",
                    SortOrder = 1,
                    ProductId = 1
                },
                new
                {
                    Id = 2,
                    ImageUrl = "/images/products/asus-rog-strix-g15-2.jpg",
                    SortOrder = 2,
                    ProductId = 1
                },
                new
                {
                    Id = 3,
                    ImageUrl = "/images/products/iphone-15-pro-1.jpg",
                    SortOrder = 1,
                    ProductId = 7
                },
                new
                {
                    Id = 4,
                    ImageUrl = "/images/products/sony-wh-1000xm5-1.jpg",
                    SortOrder = 1,
                    ProductId = 13
                }
            );
        }
    }
}