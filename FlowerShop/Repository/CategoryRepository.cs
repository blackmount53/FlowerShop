using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models;

namespace FlowerShop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private FlowerShopEntities db = new FlowerShopEntities();

        public List<Category> findAll()
        {
            return db.Categories.ToList();
        }


        public Category find(int id)
        {
            return db.Categories.Find(id);
        }

    }
}