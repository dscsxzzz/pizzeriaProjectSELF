
using COLORADO.Services;

namespace COLORADO.Data.Models
{
    public class Order
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public int price { get; set; }
        public int productQuantity { get; set; }
        public long transactionId { get; set; }
        public string? size { get; set; }
    }
}
