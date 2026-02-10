using System.Collections.Generic;

namespace DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Slug { get; set; }

        public string? Icon { get; set; }

        // FK
        public int? ParentCategoryId { get; set; }

        // Nav prop
        public Category? ParentCategory { get; set; }

        public HashSet<Category> SubCategories { get; set; } = new HashSet<Category>();

        public HashSet<Product> Products { get; set; } = new HashSet<Product>();
    }
}
