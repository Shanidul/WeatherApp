using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.WDbContext;

namespace WeatherApp.Repository
{
    public class ProductRepository:IProductRepository
    {
        WeatherDbContext _weatherDbContext;
        public ProductRepository(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        public Product AddProduct(Product product)
        {
            _weatherDbContext.Products.Add(product);
            _weatherDbContext.SaveChanges();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _weatherDbContext.Products.ToList();
        }

        public Product GetFullProductDetailsById(int id)
        {
            var existingEmployee = _weatherDbContext.Products.FirstOrDefault(e => e.Id == id);
            return existingEmployee;
        }

        public Product GetProductById(int id)
        {
            var existingProduct = _weatherDbContext.Products.FirstOrDefault(e => e.Id == id);
            return existingProduct;
        }

        public void RemoveEmployee(int id)
        {
            var existingProduct = _weatherDbContext.Products.FirstOrDefault(e => e.Id == id);
            if (existingProduct == null)
            {
                throw new Exception($"Employee with Id ={id} is not found for deletion");
            }
            _weatherDbContext.Products.Remove(existingProduct);
            _weatherDbContext.SaveChanges();
        }

        public void UpdateProduct(int id, Product product)
        {
            var existingProduct = _weatherDbContext.Products.FirstOrDefault(e => e.Id == id);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.ManufacturedBy = product.ManufacturedBy;
                _weatherDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Employee with Id ={id} is not found for updation");
            }
            
        }
    }
}
