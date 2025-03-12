using System.Collections.Generic;
using ProductApp.Entities;
using ProductApp.Models;

namespace ProductApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

        // Методы для пагинации
        IEnumerable<Product> GetProducts(int page, int pageSize);
        int GetTotalProducts();

        // Методы для фильтрации и пагинации
        IEnumerable<Product> GetFilteredProducts(ProductFilter filter, int page, int pageSize);
        int GetFilteredProductsCount(ProductFilter filter);

        IEnumerable<Product> SearchProducts(string term, int limit = 10);
    }
}
