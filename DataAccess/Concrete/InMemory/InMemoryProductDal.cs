using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 10 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Tava", UnitPrice = 60, UnitsInStock = 105 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 900, UnitsInStock = 100 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 18 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Drone", UnitPrice = 150, UnitsInStock = 25 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete= _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public List<ProdcutDetailDto> GetProductsDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürünün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;

        }
    }
}
