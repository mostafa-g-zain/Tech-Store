using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders
{
    public class SpecificationSeeder : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.HasData(
                new
                {
                    Id = 1,
                    SpecKey = "CPU",
                    SpecValue = "AMD Ryzen 9",
                    SortOrder = 1,
                    ProductId = 1
                },
                new
                {
                    Id = 2,
                    SpecKey = "GPU",
                    SpecValue = "NVIDIA RTX 4060",
                    SortOrder = 2,
                    ProductId = 1
                },
                new
                {
                    Id = 3,
                    SpecKey = "Display",
                    SpecValue = "6.1-inch Super Retina XDR",
                    SortOrder = 1,
                    ProductId = 7
                },
                new
                {
                    Id = 4,
                    SpecKey = "Chip",
                    SpecValue = "A17 Pro",
                    SortOrder = 2,
                    ProductId = 7
                }
            );
        }
    }
}