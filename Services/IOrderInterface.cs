using COLORADO.Data.FrontDTO;
using COLORADO.Data.Models;

namespace COLORADO.Services
{
    public interface IOrderInterface
    {
        Task<List<Order>> GetOrder(int id);
        Task<List<Order>> GetAllOrders();
        Task<List<IGrouping<long, Order>>> GetAllUserOrders(int userId);
        Task<IGrouping<long, Order>> GetLastUserOrder(int userId);
        Task<List<Order>> AddOrder(int id, OrderFromFront orders);

    }
}
