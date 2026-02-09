using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders
{
    public class CategorySeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                // Parent Categories
                new Category
                {
                    Id = 1,
                    Name = "Laptops",
                    Slug = "laptops",
                    Icon = "fas fa-laptop"
                },
                new Category
                {
                    Id = 2,
                    Name = "Smartphones",
                    Slug = "smartphones",
                    Icon = "fas fa-mobile-alt"
                },
                new Category
                {
                    Id = 3,
                    Name = "Accessories",
                    Slug = "accessories",
                    Icon = "fas fa-headphones"
                },
                new Category
                {
                    Id = 4,
                    Name = "Tablets",
                    Slug = "tablets",
                    Icon = "fas fa-tablet-alt"
                },
                new Category
                {
                    Id = 5,
                    Name = "Gaming",
                    Slug = "gaming",
                    Icon = "fas fa-gamepad"
                },
                
                // Sub Categories - Laptops
                new Category
                {
                    Id = 6,
                    Name = "Gaming Laptops",
                    Slug = "gaming-laptops",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 7,
                    Name = "Business Laptops",
                    Slug = "business-laptops",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 8,
                    Name = "Ultrabooks",
                    Slug = "ultrabooks",
                    ParentCategoryId = 1
                },
                
                // Sub Categories - Smartphones
                new Category
                {
                    Id = 9,
                    Name = "Android Phones",
                    Slug = "android-phones",
                    ParentCategoryId = 2
                },
                new Category
                {
                    Id = 10,
                    Name = "iPhones",
                    Slug = "iphones",
                    ParentCategoryId = 2
                },
                
                // Sub Categories - Accessories
                new Category
                {
                    Id = 11,
                    Name = "Headphones",
                    Slug = "headphones",
                    ParentCategoryId = 3
                },
                new Category
                {
                    Id = 12,
                    Name = "Keyboards & Mice",
                    Slug = "keyboards-mice",
                    ParentCategoryId = 3
                },
                new Category
                {
                    Id = 13,
                    Name = "Cases & Covers",
                    Slug = "cases-covers",
                    ParentCategoryId = 3
                }
            );
        }
    }
}
