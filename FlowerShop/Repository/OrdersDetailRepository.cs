using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models;

namespace FlowerShop.Repository
{
    public class OrdersDetailRepository : IOrdersDetailRepository
    {
        private FlowerShopEntities db = new FlowerShopEntities();
        public void create(OrdersDetail ordersDetail)
        {
            db.OrdersDetails.Add(ordersDetail);
            db.SaveChanges();
        }
    }
}