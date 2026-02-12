using System.Collections.Generic;
using System.Threading.Tasks;

using BLL.DTOs;

namespace BLL.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDetailsDto?> GetProductByIdAsync(int id);
    Task<ProductDetailsDto?> GetProductBySlugAsync(string slug);
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<ProductDto>> GetFeaturedProductsAsync(int count = 8);
    Task<IEnumerable<ProductDto>> GetBestSellersAsync(int count = 8);
    Task<IEnumerable<ProductDto>> GetHotDealsAsync(int count = 8);
}
