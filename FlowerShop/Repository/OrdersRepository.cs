using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models;
using FlowerShop.Repository;

namespace FlowerShop.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private FlowerShopEntities db = new FlowerShopEntities();

        public int create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.Id;
        }
    }
}