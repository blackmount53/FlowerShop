using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Models;

namespace FlowerShop.Repository
{
    public interface IAccountRepository
    {
        void create(Account account);
        Account login(string username, string password);
    }
}
