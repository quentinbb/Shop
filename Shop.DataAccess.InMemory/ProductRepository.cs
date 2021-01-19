using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.InMemory
{
    []
    public class ProductRepository
    {
        private ObjectCache cache = MemoryCache.Default;

        private List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void SaveChange()
        {
            cache["product"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product p)
        {
            Product prodToUpdate = products.Find(prod => prod.Id == p.Id);
            if (prodToUpdate != null)
            {
                prodToUpdate = p;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product FindById(int id)
        {
            Product p = products.Find(prod => prod.Id == id);
            if (p != null)
            {
                return p;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(int id)
        {
            Product ProdToDelete = products.Find(p => p.Id == id);
            if (ProdToDelete != null)
            {
                products.Remove(ProdToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}