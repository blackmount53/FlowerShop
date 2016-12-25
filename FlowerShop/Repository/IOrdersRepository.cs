using FlowerShop.Models;

namespace FlowerShop.Repository
{
    public interface IOrdersRepository
    {
        int create(Order order);
    }
}