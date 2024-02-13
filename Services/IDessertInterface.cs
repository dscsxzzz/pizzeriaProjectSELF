using COLORADO.Data.Models;

namespace COLORADO.Services
{
    public interface IDessertInterface
    {
        Task<List<Dessert>> GetAll();
        Task<Dessert> Get(int id);
        Task<Dessert> Add(Dessert dessert);
        Task<Dessert> Delete(int id);
        Task<Dessert> Update(int id, Dessert dessert);
        Task<List<Dessert>> AddMultiple(List<Dessert> desserts);
    }
}
