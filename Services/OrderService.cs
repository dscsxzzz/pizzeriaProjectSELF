using COLORADO.Data.DAL;
using COLORADO.Data.FrontDTO;
using COLORADO.Data.Models;

namespace COLORADO.Services
{
    public class OrderService : IOrderInterface
    {
        private DataContext context;
        public OrderService(DataContext context)
        {
            this.context = context;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<List<IGrouping<long, Order>>> GetAllUserOrders(int userId)
        {
            var allOrders = await context.Orders.Where(w => w.userId == userId).ToListAsync();
            var groupedOrders = allOrders.GroupBy(w => w.transactionId).ToList();
            return groupedOrders;
        }

        public async Task<IGrouping<long, Order>> GetLastUserOrder(int userId)
        {
            var allOrders = await context.Orders.Where(w => w.userId == userId).ToListAsync();
            var groupedOrders = allOrders.GroupBy(w => w.transactionId).ToList();
            return groupedOrders.Last();
        }


    public async Task<List<Order>> GetOrder(int transactionId)
        {
            var order = await context.Orders.Where(p => p.transactionId == transactionId).ToListAsync();
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<List<Order>> AddOrder(int id, OrderFromFront order) 
        {
            List<Order> orderList = new List<Order>();
            var date = DateTime.Now;
            long transactionId = long.Parse(date.ToString("yyyyMMddHHmmssffff"));

            if (order.pizzas is not null)
            {
                
                foreach (var pizz in order.pizzas)
                {
                    orderList.Add(new Order
                    {
                        productId = pizz.pizza.id,
                        productQuantity = pizz.amount,
                        userId = id,
                        productName = pizz.pizza.name,
                        transactionId = transactionId,
                        productType = "pizza",
                        price = pizz.price,
                        size = pizz.size

                    });
                }
            }
            if (order.desserts is not null)
            {
                
                foreach (var dessert in order.desserts)
                {
                    orderList.Add(new Order
                    {
                        productId = dessert.dessert.id,
                        productQuantity = dessert.amount,
                        productName = dessert.dessert.name,
                        userId = id,
                        productType = "dessert",
                        price = dessert.price,
                        transactionId = transactionId,
                        size = "normal"

                    });
                }
            }
            await context.Orders.AddRangeAsync(orderList);
            await context.SaveChangesAsync();
            return orderList;

        }

    }


}