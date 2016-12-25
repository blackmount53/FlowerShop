using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models;

namespace FlowerShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private FlowerShopEntities db = new FlowerShopEntities();
        public List<Product> FeaturedProducts(int n)
        {
            return db.Products.Where(p => p.specials==true).Take(n).ToList();
        }

        public Product find(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> LatestProducts()
        {
            return db.Products.OrderByDescending(p => p.Id).ToList();
        }

        public List<Product> LatestProducts(int n)
        {
            return db.Products.OrderByDescending(p => p.Id).Take(n).ToList();
        }

        public List<Product> RelatedProducts(Product product, int n)
        {
            return db.Products.Where(p => p.categoryId == product.categoryId && p.Id != product.Id).Take(n).ToList();
        }

        public List<Product> SpecialProducts()
        {
            return db.Products.Where(p => p.specials == true).ToList();
        }
    }
}