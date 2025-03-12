using System.Collections.Generic;
using ProductApp.Entities;
using ProductApp.DAO;
using ProductApp.Models;

namespace ProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDao _productDao;

        public ProductService(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productDao.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _productDao.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _productDao.Add(product);
            _productDao.Save();
        }

        public void UpdateProduct(Product product)
        {
            _productDao.Update(product);
            _productDao.Save();
        }

        public void DeleteProduct(int id)
        {
            _productDao.Delete(id);
            _productDao.Save();
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize)
        {
            return _productDao.GetProducts(page, pageSize);
        }

        public int GetTotalProducts()
        {
            return _productDao.GetTotalProducts();
        }

        public IEnumerable<Product> GetFilteredProducts(ProductFilter filter, int page, int pageSize)
        {
            return _productDao.GetFilteredProducts(filter, page, pageSize);
        }

        public int GetFilteredProductsCount(ProductFilter filter)
        {
            return _productDao.GetFilteredProductsCount(filter);
        }


        public IEnumerable<Product> SearchProducts(string term, int limit = 10)
        {
            return _productDao.SearchProducts(term, limit);
        }
    }
}
