using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappings;

using DAL.Contexts;

using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .ProjectToCategoryDto()
            .ToListAsync();
    }

    public async Task<IEnumerable<CategoryDto>> GetParentCategoriesAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .Where(c => c.ParentCategoryId == null)
            .Include(c => c.SubCategories)
            .ProjectToCategoryDto()
            .ToListAsync();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == id);

        return category?.ToCategoryDto();
    }

    public async Task<CategoryDto?> GetCategoryBySlugAsync(string slug)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Slug == slug);

        return category?.ToCategoryDto();
    }
}
