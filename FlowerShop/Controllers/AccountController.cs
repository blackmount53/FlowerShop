using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;
using FlowerShop.Repository;

namespace FlowerShop.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository iAccountRepository = new AccountRepository();
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            iAccountRepository.create(account);
            return RedirectToAction("MyAccount","Account");
        }
        public ActionResult MyAccount()
        {
            return View("MyAccount");
        }

        [HttpPost]
        public ActionResult MyAccount(Account account)
        {
            Account acc = iAccountRepository.login(account.username, account.password);
            if(acc== null)
            {
                ViewBag.error = "Account's Invalid ";
                return ViewBag("MyAccount");
            }
            else
            {
                Session["username"] = acc.username;
                return View("Welcome");
            }
            
        }

    }
}