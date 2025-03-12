using System.Collections.Generic;
using System.Linq;
using ProductApp.Entities;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.DAO
{
    public class ProductDao : IProductDao
    {
        private readonly ProductDbContext _context;

        public ProductDao(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize)
        {
            return _context.Products
                           .OrderBy(p => p.Id)
                           .Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }

        public int GetTotalProducts()
        {
            return _context.Products.Count();
        }

         public IEnumerable<Product> GetFilteredProducts(ProductFilter filter, int page, int pageSize)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(filter.Gender))
            {
                query = query.Where(p => p.Gender == filter.Gender);
            }

            if (filter.Types != null && filter.Types.Any())
            {
                query = query.Where(p => filter.Types.Contains(p.Type));
            }

            if (filter.Colors != null && filter.Colors.Any())
            {
                query = query.Where(p => filter.Colors.Contains(p.Color));
            }

            if (filter.PriceFrom.HasValue)
            {
                query = query.Where(p => p.Price >= filter.PriceFrom.Value);
            }

            if (filter.PriceTo.HasValue)
            {
                query = query.Where(p => p.Price <= filter.PriceTo.Value);
            }

            return query.OrderBy(p => p.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public int GetFilteredProductsCount(ProductFilter filter)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(filter.Gender))
            {
                query = query.Where(p => p.Gender == filter.Gender);
            }

            if (filter.Types != null && filter.Types.Any())
            {
                query = query.Where(p => filter.Types.Contains(p.Type));
            }

            if (filter.Colors != null && filter.Colors.Any())
            {
                query = query.Where(p => filter.Colors.Contains(p.Color));
            }

            if (filter.PriceFrom.HasValue)
            {
                query = query.Where(p => p.Price >= filter.PriceFrom.Value);
            }

            if (filter.PriceTo.HasValue)
            {
                query = query.Where(p => p.Price <= filter.PriceTo.Value);
            }

            return query.Count();
        }


        public IEnumerable<Product> SearchProducts(string term, int limit = 10)
        {
            if (string.IsNullOrWhiteSpace(term))
                return new List<Product>();

            return _context.Products
                .Where(p => p.Name.Contains(term))
                .OrderBy(p => p.Name)
                .Take(limit)
                .ToList();
        }
    }
}
