using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders
{
    public class BrandSeeder : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Apple",
                    LogoUrl = "/images/brands/apple.png"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Samsung",
                    LogoUrl = "/images/brands/samsung.png"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Dell",
                    LogoUrl = "/images/brands/dell.png"
                },
                new Brand
                {
                    Id = 4,
                    Name = "HP",
                    LogoUrl = "/images/brands/hp.png"
                },
                new Brand
                {
                    Id = 5,
                    Name = "Lenovo",
                    LogoUrl = "/images/brands/lenovo.png"
                },
                new Brand
                {
                    Id = 6,
                    Name = "ASUS",
                    LogoUrl = "/images/brands/asus.png"
                },
                new Brand
                {
                    Id = 7,
                    Name = "Acer",
                    LogoUrl = "/images/brands/acer.png"
                },
                new Brand
                {
                    Id = 8,
                    Name = "Microsoft",
                    LogoUrl = "/images/brands/microsoft.png"
                },
                new Brand
                {
                    Id = 9,
                    Name = "Sony",
                    LogoUrl = "/images/brands/sony.png"
                },
                new Brand
                {
                    Id = 10,
                    Name = "Xiaomi",
                    LogoUrl = "/images/brands/xiaomi.png"
                }
            );
        }
    }
}
