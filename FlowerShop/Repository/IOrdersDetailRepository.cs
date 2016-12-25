using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Repository
{
    public interface IOrdersDetailRepository
    {
        void create(OrdersDetail ordersDetail);
    }
}
