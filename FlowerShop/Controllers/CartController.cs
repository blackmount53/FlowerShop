using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Repository;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();
        private IOrdersRepository iOrdersRepository = new OrdersRepository();
        private IOrdersDetailRepository iOrdersDetailRepository = new OrdersDetailRepository();

        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Buy(int id)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item()
                {
                    product = iProductRepository.find(id),
                    quantity= 1
                });
                Session["cart"] = cart;
            }else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExits(id);
                if(index == -1)
                {
                    cart.Add(new Item()
                    {
                        product = iProductRepository.find(id),
                        quantity = 1
                    });
                }
                else
                {
                    cart[index].quantity++;
                }
                
                Session["cart"] = cart;
            }
            return View("Index");
        }

        private int isExits(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)           
                if (cart[i].product.Id == id)
                    return i;
            return -1;
        }

        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("Index");
        }

        public ActionResult Checkout()
        {
            if(Session["username"] == null)
            {
                return RedirectToAction("MyAccount", "Account");
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                // Save order
                Order order = new Order();
                order.creationDate = DateTime.Now;
                order.name = "New Order";
                order.payment = "Paypal";
                order.status = true;
                order.username = Session["username"].ToString();
                int orderId = iOrdersRepository.create(order);
                // Save order detail
                foreach (var item in cart) { 
                    OrdersDetail ordersDetail = new OrdersDetail();
                    ordersDetail.ordersId = orderId;
                    ordersDetail.productId = item.product.Id;
                    ordersDetail.price = item.product.price;
                    ordersDetail.quantity = item.quantity;
                    iOrdersDetailRepository.create(ordersDetail);
                }
                // remove cart
                Session.Remove("cart");

                return View("Thanks");
            }
        }

    }
}