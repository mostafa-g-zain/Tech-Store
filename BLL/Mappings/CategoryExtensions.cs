using System;
using System.Collections.Generic;
using System.Text;

using BLL.DTOs;

using DAL.Entities;

namespace BLL.Mappings;

public static class CategoryExtensions
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        if (category == null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Slug = category.Slug,
            Icon = category.Icon,
            SubCategories = category.SubCategories?.Select(sc => sc.ToCategoryDto()).ToList() ?? new List<CategoryDto>()    //RECURSIVELY.
        };
    }
    public static Category ToCategoryEntity(this CategoryDto dto)
    {
        if (dto == null)
            return null;

        return new Category
        {
            Id = dto.Id,
            Name = dto.Name,
            Slug = dto.Slug,
            Icon = dto.Icon
        };
    }
    public static IQueryable<CategoryDto> ProjectToCategoryDto(this IQueryable<Category> categories)
    {
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Slug = c.Slug,
            Icon = c.Icon,
            SubCategories = c.SubCategories.Select(sc => new CategoryDto
            {
                Id = sc.Id,
                Name = sc.Name,
                Slug = sc.Slug,
                Icon = sc.Icon
            }).ToList()
        });
    }
}
