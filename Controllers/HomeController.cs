using Microsoft.AspNetCore.Mvc;
using ProductApp.Services;
using ProductApp.Models;
using System;
using System.Linq;

namespace ProductApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private const int PageSize = 9;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /Home/Index или просто /
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Catalog(
            string? gender,
            string? types,      // ожидается строка с разделителем, например, "Боди,Платье"
            string? colors,     // аналогично
            decimal? priceFrom,
            decimal? priceTo,
            int page = 1)
        {
            var filter = new ProductFilter
            {
                Gender = gender,
                // Если types не пустая, разделяем запятой
                Types = string.IsNullOrWhiteSpace(types) ? null : types.Split(',').Select(t => t.Trim()).ToList(),
                Colors = string.IsNullOrWhiteSpace(colors) ? null : colors.Split(',').Select(c => c.Trim()).ToList(),
                PriceFrom = priceFrom,
                PriceTo = priceTo
            };

            int totalProducts = _productService.GetFilteredProductsCount(filter);
            int totalPages = (int)Math.Ceiling(totalProducts / (double)PageSize);

            var products = _productService.GetFilteredProducts(filter, page, PageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            // Можно также передать параметры фильтра обратно для поддержания состояния формы

            return View(products);
        }

        // Действие для асинхронной подгрузки (пагинации) с фильтром
        public IActionResult GetProductsPage(
            string? gender,
            string? types,
            string? colors,
            decimal? priceFrom,
            decimal? priceTo,
            int page = 1)
        {
            var filter = new ProductFilter
            {
                Gender = gender,
                Types = string.IsNullOrWhiteSpace(types) ? null : types.Split(',').Select(t => t.Trim()).ToList(),
                Colors = string.IsNullOrWhiteSpace(colors) ? null : colors.Split(',').Select(c => c.Trim()).ToList(),
                PriceFrom = priceFrom,
                PriceTo = priceTo
            };

            var products = _productService.GetFilteredProducts(filter, page, PageSize);
            return PartialView("_ProductList", products);
        }

        // Можно добавить действие для отображения деталей товара
        public IActionResult Product(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Delivery()
        {
            return View();
        }


        [HttpGet]
        public IActionResult SearchProducts(string term)
        {
            var results = _productService.SearchProducts(term);
            // Для автодополнения обычно возвращают только id и name
            var suggestions = results.Select(p => new { p.Id, p.Name }).ToList();
            return Json(suggestions);
        }

        [HttpGet]
        public IActionResult SearchProductsPage(string searchTerm)
        {
            // Если запрос пустой, можно вернуть все товары или пустой список, как требуется
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Например, вернуть первую страницу без фильтра
                var allProducts = _productService.GetFilteredProducts(new ProductFilter(), 1, 9);
                return PartialView("_ProductList", allProducts);
            }
            // Ищем товары, где название содержит введённый запрос (без учета регистра)
            var filteredProducts = _productService.GetAllProducts()
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return PartialView("_ProductList", filteredProducts);
        }
    }
}
