using System;

using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders
{
    public class ProductSeeder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var seedDate = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
            const string placeholderImage = "/Images/placeholder.png";

            builder.HasData(
                // Gaming Laptops
                new Product
                {
                    Id = 1,
                    Name = "ASUS ROG Strix G15",
                    Slug = "asus-rog-strix-g15",
                    ShortDescription = "High-performance gaming laptop with RTX 4060",
                    Description = "Powerful gaming laptop featuring AMD Ryzen 9 processor, NVIDIA RTX 4060 graphics, 16GB RAM, and 512GB SSD. 15.6-inch 144Hz display for smooth gameplay.",
                    Price = 1299.99m,
                    OldPrice = 1499.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 25,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 6,
                    BrandId = 6,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "ASUS ROG Strix G15 Gaming Laptop",
                    MetaDescription = "Buy ASUS ROG Strix G15 gaming laptop with RTX 4060 graphics card"
                },
                new Product
                {
                    Id = 2,
                    Name = "Acer Predator Helios 300",
                    Slug = "acer-predator-helios-300",
                    ShortDescription = "Affordable gaming powerhouse",
                    Description = "Intel Core i7, RTX 4050, 16GB DDR5 RAM, 512GB NVMe SSD. 15.6-inch FHD 165Hz display with excellent cooling system.",
                    Price = 1099.99m,
                    OldPrice = 1299.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 30,
                    IsHot = true,
                    IsFeatured = false,
                    IsBestSeller = true,
                    CategoryId = 6,
                    BrandId = 7,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Acer Predator Helios 300 Gaming Laptop",
                    MetaDescription = "Affordable gaming laptop with great performance"
                },

                // Business Laptops
                new Product
                {
                    Id = 3,
                    Name = "Dell Latitude 5420",
                    Slug = "dell-latitude-5420",
                    ShortDescription = "Professional business laptop",
                    Description = "Intel Core i5-11th Gen, 8GB RAM, 256GB SSD. 14-inch FHD display with enterprise-level security features.",
                    Price = 899.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 40,
                    IsHot = false,
                    IsFeatured = true,
                    IsBestSeller = false,
                    CategoryId = 7,
                    BrandId = 3,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Dell Latitude 5420 Business Laptop",
                    MetaDescription = "Professional Dell Latitude laptop for business users"
                },
                new Product
                {
                    Id = 4,
                    Name = "HP EliteBook 840 G8",
                    Slug = "hp-elitebook-840-g8",
                    ShortDescription = "Premium business ultrabook",
                    Description = "Intel Core i7-11th Gen, 16GB RAM, 512GB SSD. 14-inch FHD touch display with premium build quality.",
                    Price = 1199.99m,
                    OldPrice = 1399.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 20,
                    IsHot = false,
                    IsFeatured = true,
                    IsBestSeller = false,
                    CategoryId = 7,
                    BrandId = 4,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "HP EliteBook 840 G8 Business Laptop",
                    MetaDescription = "Premium HP EliteBook for professionals"
                },

                // Ultrabooks
                new Product
                {
                    Id = 5,
                    Name = "MacBook Air M3",
                    Slug = "macbook-air-m3",
                    ShortDescription = "Ultra-thin and powerful",
                    Description = "Apple M3 chip, 8GB unified memory, 256GB SSD. 13.6-inch Liquid Retina display with exceptional battery life.",
                    Price = 1099.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 50,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 8,
                    BrandId = 1,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "MacBook Air M3 - Ultra-thin Laptop",
                    MetaDescription = "Latest MacBook Air with M3 chip"
                },
                new Product
                {
                    Id = 6,
                    Name = "Dell XPS 13",
                    Slug = "dell-xps-13",
                    ShortDescription = "Premium Windows ultrabook",
                    Description = "Intel Core i7-13th Gen, 16GB RAM, 512GB SSD. 13.4-inch InfinityEdge FHD+ display in compact design.",
                    Price = 1299.99m,
                    OldPrice = 1499.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 35,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = false,
                    CategoryId = 8,
                    BrandId = 3,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Dell XPS 13 Ultrabook",
                    MetaDescription = "Premium Dell XPS 13 with stunning display"
                },

                // iPhones
                new Product
                {
                    Id = 7,
                    Name = "iPhone 15 Pro",
                    Slug = "iphone-15-pro",
                    ShortDescription = "Titanium design with A17 Pro chip",
                    Description = "6.1-inch Super Retina XDR display, A17 Pro chip, 128GB storage, titanium design, advanced camera system.",
                    Price = 999.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 100,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 10,
                    BrandId = 1,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "iPhone 15 Pro - Latest Apple Smartphone",
                    MetaDescription = "Buy iPhone 15 Pro with A17 Pro chip"
                },
                new Product
                {
                    Id = 8,
                    Name = "iPhone 15",
                    Slug = "iphone-15",
                    ShortDescription = "The latest iPhone with Dynamic Island",
                    Description = "6.1-inch Super Retina XDR display, A16 Bionic chip, 128GB storage, dual camera system.",
                    Price = 799.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 120,
                    IsHot = true,
                    IsFeatured = false,
                    IsBestSeller = true,
                    CategoryId = 10,
                    BrandId = 1,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "iPhone 15 - Latest Apple Smartphone",
                    MetaDescription = "Buy iPhone 15 with Dynamic Island"
                },

                // Android Phones
                new Product
                {
                    Id = 9,
                    Name = "Samsung Galaxy S24 Ultra",
                    Slug = "samsung-galaxy-s24-ultra",
                    ShortDescription = "Ultimate flagship Android phone",
                    Description = "6.8-inch Dynamic AMOLED 2X display, Snapdragon 8 Gen 3, 12GB RAM, 256GB storage, 200MP camera, S Pen included.",
                    Price = 1199.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 60,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 9,
                    BrandId = 2,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Samsung Galaxy S24 Ultra Smartphone",
                    MetaDescription = "Premium Samsung Galaxy S24 Ultra with S Pen"
                },
                new Product
                {
                    Id = 10,
                    Name = "Xiaomi 14 Pro",
                    Slug = "xiaomi-14-pro",
                    ShortDescription = "Flagship killer with Leica camera",
                    Description = "6.73-inch AMOLED display, Snapdragon 8 Gen 3, 12GB RAM, 256GB storage, Leica triple camera system.",
                    Price = 899.99m,
                    OldPrice = 999.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 45,
                    IsHot = true,
                    IsFeatured = false,
                    IsBestSeller = false,
                    CategoryId = 9,
                    BrandId = 10,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Xiaomi 14 Pro Smartphone",
                    MetaDescription = "Xiaomi 14 Pro with Leica camera system"
                },

                // Tablets
                new Product
                {
                    Id = 11,
                    Name = "iPad Pro 12.9\"",
                    Slug = "ipad-pro-12-9",
                    ShortDescription = "Ultimate iPad with M2 chip",
                    Description = "12.9-inch Liquid Retina XDR display, M2 chip, 128GB storage, Apple Pencil support, professional performance.",
                    Price = 1099.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 40,
                    IsHot = false,
                    IsFeatured = true,
                    IsBestSeller = false,
                    CategoryId = 4,
                    BrandId = 1,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "iPad Pro 12.9 inch - Professional Tablet",
                    MetaDescription = "iPad Pro 12.9 with M2 chip for professionals"
                },
                new Product
                {
                    Id = 12,
                    Name = "Samsung Galaxy Tab S9",
                    Slug = "samsung-galaxy-tab-s9",
                    ShortDescription = "Premium Android tablet",
                    Description = "11-inch Dynamic AMOLED 2X display, Snapdragon 8 Gen 2, 8GB RAM, 128GB storage, S Pen included.",
                    Price = 799.99m,
                    OldPrice = 899.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 55,
                    IsHot = false,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 4,
                    BrandId = 2,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Samsung Galaxy Tab S9 Tablet",
                    MetaDescription = "Premium Samsung tablet with S Pen"
                },

                // Headphones
                new Product
                {
                    Id = 13,
                    Name = "Sony WH-1000XM5",
                    Slug = "sony-wh-1000xm5",
                    ShortDescription = "Industry-leading noise cancellation",
                    Description = "Premium wireless headphones with exceptional noise cancellation, 30-hour battery life, superior sound quality.",
                    Price = 399.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 80,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 11,
                    BrandId = 9,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "Sony WH-1000XM5 Wireless Headphones",
                    MetaDescription = "Premium Sony headphones with noise cancellation"
                },
                new Product
                {
                    Id = 14,
                    Name = "Apple AirPods Pro (2nd Gen)",
                    Slug = "apple-airpods-pro-2",
                    ShortDescription = "Premium wireless earbuds",
                    Description = "Active noise cancellation, adaptive transparency, personalized spatial audio with H2 chip.",
                    Price = 249.99m,
                    OldPrice = 0m,
                    MainImage = placeholderImage,
                    StockQuantity = 150,
                    IsHot = true,
                    IsFeatured = true,
                    IsBestSeller = true,
                    CategoryId = 11,
                    BrandId = 1,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "AirPods Pro 2nd Generation",
                    MetaDescription = "Apple AirPods Pro with active noise cancellation"
                },

                // Gaming Accessories
                new Product
                {
                    Id = 15,
                    Name = "ASUS ROG Strix Scope II Gaming Keyboard",
                    Slug = "asus-rog-strix-scope-ii",
                    ShortDescription = "Mechanical gaming keyboard",
                    Description = "ROG NX mechanical switches, RGB lighting, dedicated media controls, USB passthrough.",
                    Price = 149.99m,
                    OldPrice = 179.99m,
                    MainImage = placeholderImage,
                    StockQuantity = 70,
                    IsHot = false,
                    IsFeatured = false,
                    IsBestSeller = true,
                    CategoryId = 12,
                    BrandId = 6,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    MetaTitle = "ASUS ROG Strix Scope II Gaming Keyboard",
                    MetaDescription = "Mechanical gaming keyboard with RGB lighting"
                }
            );
        }
    }
}
