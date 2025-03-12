using System.Collections.Generic;
using ProductApp.Entities;
using ProductApp.Models;

namespace ProductApp.DAO
{
    public interface IProductDao
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();

        // Новые методы для пагинации
        IEnumerable<Product> GetProducts(int page, int pageSize);
        int GetTotalProducts();

        IEnumerable<Product> GetFilteredProducts(ProductFilter filter, int page, int pageSize);
        int GetFilteredProductsCount(ProductFilter filter);


        IEnumerable<Product> SearchProducts(string term, int limit = 10);
    }
}
