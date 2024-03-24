
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product GetProductById(int id);
        Product GetFullProductDetailsById(int id);
        void UpdateProduct(int id, Product product);

        void RemoveEmployee(int id);
    }
}
