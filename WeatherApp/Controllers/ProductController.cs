using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Repository;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();

            List<ProductDetailsViewModel> productDetailsListViewModel = new List<ProductDetailsViewModel>();
            foreach (var product in products)
            {
                ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Description = product.Description,
                    ManufacturedBy=product.ManufacturedBy
                };
                productDetailsListViewModel.Add(productDetailsViewModel);
            }

            return View(productDetailsListViewModel);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            var addProductViewModel = new AddProductViewModel();
            return View(addProductViewModel);
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = productViewModel.ProductName,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price,
                    ManufacturedBy= productViewModel.ManufacturedBy
                };

                var addedProduct = _productRepository.AddProduct(product);

                return RedirectToAction("Index");
            }

            return View(productViewModel);

        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var updateProductViewModel = new UpdateProductViewModel();
            var productToBeEdited = _productRepository.GetProductById(id);
            updateProductViewModel.Id = productToBeEdited.Id;
            updateProductViewModel.ProductName = productToBeEdited.ProductName;
            updateProductViewModel.Description = productToBeEdited.Description;
            updateProductViewModel.Price = productToBeEdited.Price;
            updateProductViewModel.ManufacturedBy = productToBeEdited.ManufacturedBy;
            return View(updateProductViewModel);
        }


        [HttpPost]
        public IActionResult UpdateProduct(int id, UpdateProductViewModel updateProductViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductName = updateProductViewModel.ProductName,
                    Description = updateProductViewModel.Description,
                    Price = updateProductViewModel.Price,
                    ManufacturedBy= updateProductViewModel.ManufacturedBy
                };
                _productRepository.UpdateProduct(id, product);
                return RedirectToAction("Index");
            }

            return View(updateProductViewModel);

        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var productToBeDeleted = _productRepository.GetFullProductDetailsById(id);
            var deleteProductViewModel = new DeleteProductViewModel
            {
                Id = productToBeDeleted.Id,
                ProductName = productToBeDeleted.ProductName,
                Description = productToBeDeleted.Description,
                Price = productToBeDeleted.Price,
                ManufacturedBy=productToBeDeleted.ManufacturedBy
            };
            return View(deleteProductViewModel);
        }


        [HttpPost]
        public IActionResult DeleteProduct(DeleteProductViewModel deleteProductViewModel)
        {
            _productRepository.RemoveEmployee(deleteProductViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}
