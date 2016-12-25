using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models;

namespace FlowerShop.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private FlowerShopEntities db = new FlowerShopEntities();
        public void create(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public Account login(string username, string password)
        {
            //var account = db.Accounts.Where(a => a.username == username && a.password == password).SingleOrDefault();
            //return account;
            try
            {
                return db.Accounts.Single(account => account.username.Equals(username) && account.password.Equals(password));
            }
            catch 
            {
                return null;
            }

        }
    }
}