using System.Threading.Tasks;

using BLL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    // GET: /Products
    public async Task<IActionResult> Index(int? categoryId)
    {
        var products = categoryId.HasValue
            ? await _productService.GetProductsByCategoryAsync(categoryId.Value)
            : await _productService.GetAllProductsAsync();

        ViewBag.Categories = await _categoryService.GetParentCategoriesAsync();
        ViewBag.SelectedCategoryId = categoryId;

        return View(products);
    }

    // GET: /Products/Details/5 or /Products/Details/macbook-air-m3
    public async Task<IActionResult> Details(string id)
    {
        if (string.IsNullOrEmpty(id))
            return NotFound();

        // Try to parse as int (ID), otherwise treat as slug
        var product = int.TryParse(id, out var productId)
            ? await _productService.GetProductByIdAsync(productId)
            : await _productService.GetProductBySlugAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }
}
