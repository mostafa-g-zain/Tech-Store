using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL.DTOs;
using BLL.Interfaces;

using DAL.Contexts;
using DAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Select(p => new ProductDto
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
                CategoryName = p.ParentCategory != null ? p.ParentCategory.Name : null,
                BrandName = p.ParentBrand != null ? p.ParentBrand.Name : null
            })
            .ToListAsync();
    }

    public async Task<ProductDetailsDto?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Include(p => p.ProductImages)
            .Include(p => p.Specifications)
            .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return null;

        return MapToDetailsDto(product);
    }

    public async Task<ProductDetailsDto?> GetProductBySlugAsync(string slug)
    {
        var product = await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Include(p => p.ProductImages)
            .Include(p => p.Specifications)
            .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(p => p.Slug == slug);

        if (product == null)
            return null;

        return MapToDetailsDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Where(p => p.CategoryId == categoryId)
            .Select(p => new ProductDto
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
                CategoryName = p.ParentCategory != null ? p.ParentCategory.Name : null,
                BrandName = p.ParentBrand != null ? p.ParentBrand.Name : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetFeaturedProductsAsync(int count = 8)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Where(p => p.IsFeatured)
            .OrderByDescending(p => p.CreatedAt)
            .Take(count)
            .Select(p => new ProductDto
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
                CategoryName = p.ParentCategory != null ? p.ParentCategory.Name : null,
                BrandName = p.ParentBrand != null ? p.ParentBrand.Name : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetBestSellersAsync(int count = 8)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Where(p => p.IsBestSeller)
            .OrderByDescending(p => p.CreatedAt)
            .Take(count)
            .Select(p => new ProductDto
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
                CategoryName = p.ParentCategory != null ? p.ParentCategory.Name : null,
                BrandName = p.ParentBrand != null ? p.ParentBrand.Name : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetHotDealsAsync(int count = 8)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Where(p => p.IsHot && p.OldPrice > 0)
            .OrderByDescending(p => p.CreatedAt)
            .Take(count)
            .Select(p => new ProductDto
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
                CategoryName = p.ParentCategory != null ? p.ParentCategory.Name : null,
                BrandName = p.ParentBrand != null ? p.ParentBrand.Name : null
            })
            .ToListAsync();
    }

    private ProductDetailsDto MapToDetailsDto(Product product)
    {
        var approvedReviews = product.Reviews.Where(r => r.IsApproved).ToList();

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
            Images = product.ProductImages
                .OrderBy(i => i.SortOrder)
                .Select(i => new ProductImageDto
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    SortOrder = i.SortOrder
                })
                .ToList(),
            Specifications = product.Specifications
                .OrderBy(s => s.SortOrder)
                .Select(s => new SpecificationDto
                {
                    Id = s.Id,
                    SpecKey = s.SpecKey,
                    SpecValue = s.SpecValue,
                    SortOrder = s.SortOrder
                })
                .ToList(),
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
