using System;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Slug { get; set; }

        public string? ShortDescription { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public string? MainImage { get; set; }

        public int StockQuantity { get; set; }

        public bool IsHot { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsBestSeller { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        // FK
        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        // Nav prop
        public Category? ParentCategory { get; set; }

        public Brand? ParentBrand { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
        public ICollection<Specification> Specifications { get; set; } = new HashSet<Specification>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
