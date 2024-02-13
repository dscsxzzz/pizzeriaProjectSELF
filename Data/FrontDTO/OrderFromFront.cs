using COLORADO.Data.Models;

namespace COLORADO.Data.FrontDTO
{
    public class OrderFromFront
    {
        public List<PizzaFront>? pizzas { get; set; }
        public List<DessertFront>? desserts { get; set; }
    }
}
