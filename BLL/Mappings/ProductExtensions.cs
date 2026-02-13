using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLL.DTOs;

using DAL.Entities;

namespace BLL.Mappings;

public static class ProductExtensions
{
    public static ProductDto ToProductDto(this Product product)
    {
        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Slug = product.Slug,
            ShortDescription = product.ShortDescription,
            Description = product.Description,
            Price = product.Price,
            OldPrice = product.OldPrice,
            MainImage = product.MainImage,
            StockQuantity = product.StockQuantity,
            IsHot = product.IsHot,
            IsFeatured = product.IsFeatured,
            IsBestSeller = product.IsBestSeller,
            CategoryName = product.ParentCategory?.Name,
            BrandName = product.ParentBrand?.Name
        };
    }

    public static Product ToProductEntity(this ProductDto dto)
    {
        if (dto == null)
            return null;

        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Slug = dto.Slug,
            ShortDescription = dto.ShortDescription,
            Description = dto.Description,
            Price = dto.Price,
            OldPrice = dto.OldPrice,
            MainImage = dto.MainImage,
            StockQuantity = dto.StockQuantity,
            IsHot = dto.IsHot,
            IsFeatured = dto.IsFeatured,
            IsBestSeller = dto.IsBestSeller
        };
    }

    public static IQueryable<ProductDto> ProjectToProductDto(this IQueryable<Product> products)
    {
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Slug = p.Slug,
            ShortDescription = p.ShortDescription,
            Description = p.Description,
            Price = p.Price,
            OldPrice = p.OldPrice,
            MainImage = p.MainImage,
            StockQuantity = p.StockQuantity,
            IsHot = p.IsHot,
            IsFeatured = p.IsFeatured,
            IsBestSeller = p.IsBestSeller,
            CategoryName = p.ParentCategory.Name,
            BrandName = p.ParentBrand.Name
        });
    }

    public static ProductDetailsDto ToProductDetailsDto(this Product product)
    {
        if (product == null)
            return null;

        var approvedReviews = product.Reviews?.Where(r => r.IsApproved).ToList() ?? new List<Review>();

        return new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            Slug = product.Slug,
            ShortDescription = product.ShortDescription,
            Description = product.Description,
            Price = product.Price,
            OldPrice = product.OldPrice,
            MainImage = product.MainImage,
            StockQuantity = product.StockQuantity,
            IsHot = product.IsHot,
            IsFeatured = product.IsFeatured,
            IsBestSeller = product.IsBestSeller,
            CategoryName = product.ParentCategory?.Name,
            BrandName = product.ParentBrand?.Name,
            MetaTitle = product.MetaTitle,
            MetaDescription = product.MetaDescription,
            Images = product.ProductImages?
                .OrderBy(i => i.SortOrder)
                .Select(i => new ProductImageDto
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    SortOrder = i.SortOrder
                })
                .ToList() ?? new List<ProductImageDto>(),
            Specifications = product.Specifications?
                .OrderBy(s => s.SortOrder)
                .Select(s => new SpecificationDto
                {
                    Id = s.Id,
                    SpecKey = s.SpecKey,
                    SpecValue = s.SpecValue,
                    SortOrder = s.SortOrder
                })
                .ToList() ?? new List<SpecificationDto>(),
            Reviews = approvedReviews
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    UserName = r.User?.FullName ?? "Anonymous",
                    CreatedAt = r.CreatedAt
                })
                .ToList(),
            AverageRating = approvedReviews.Any() ? approvedReviews.Average(r => r.Rating) : 0,
            ReviewCount = approvedReviews.Count
        };
    }
}
