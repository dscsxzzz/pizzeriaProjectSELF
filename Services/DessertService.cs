using COLORADO.Data.DAL;
using COLORADO.Data.Models;
using System.Xml.Linq;

namespace COLORADO.Services
{
    public class DessertService : IDessertInterface
    {
       
        DataContext context;
        public DessertService(DataContext context) {
            this.context = context;
        }
            
        public async Task<List<Dessert>> GetAll() => await context.Desserts.ToListAsync();

        public async Task<Dessert>? Get(int id) { 
            return await context.Desserts.FirstOrDefaultAsync(p => p.id == id); 

        }

        public async Task<Dessert> Add(Dessert dessert)
        {
            context.Desserts.Add(dessert);
            await context.SaveChangesAsync();
            return dessert;
        }

        public async Task<List<Dessert>> AddMultiple(List<Dessert> desserts)
        {
            context.Desserts.AddRange(desserts);
            await context.SaveChangesAsync();
            return desserts;
        }

        public async Task<Dessert> Delete(int id)
        {
            var dessert = await context.Desserts.FindAsync(id);
            if (dessert is null)
                return dessert;

            context.Desserts.Remove(dessert);
            await context.SaveChangesAsync();
            return dessert;
        }

        public async Task<Dessert> Update(int id, Dessert dessert)
        {
            var existingDessert = await context.Desserts.FindAsync(id);
            if (existingDessert is null)
            {
                return existingDessert;
            }

            existingDessert.id = dessert.id;
            existingDessert.name = dessert.name;
            existingDessert.price = dessert.price;
            existingDessert.description = dessert.description;
            existingDessert.img = dessert.img;
            await context.SaveChangesAsync();
            return dessert;
        }
    }
}

