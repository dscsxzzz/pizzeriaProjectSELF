using COLORADO.Data.Models;

namespace COLORADO.Services
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetAll();
        Task<List<Pizza>> GetPizzasByIds(List<int> ids);
        Task<Pizza> Get(int id);
        Task<Pizza> Add(Pizza pizza);
        Task<List<Pizza>> AddMultiple(List<Pizza> pizzas);
        Task<Pizza> Delete(int id);
        Task<Pizza> Update(int id, Pizza pizza);
    }
}
