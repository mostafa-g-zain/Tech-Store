using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappings;

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
            .ProjectToProductDto()
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

        return product?.ToProductDetailsDto();
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

        return product?.ToProductDetailsDto();
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.ParentCategory)
            .Include(p => p.ParentBrand)
            .Where(p => p.CategoryId == categoryId)
            .ProjectToProductDto()
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
            .ProjectToProductDto()
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
            .ProjectToProductDto()
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
            .ProjectToProductDto()
            .ToListAsync();
    }
}
