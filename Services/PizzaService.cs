using COLORADO.Data.DAL;
using COLORADO.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Services;

public class PizzaService : IPizzaService
{
    DataContext context;
    public PizzaService(DataContext context)
    {
        this.context = context;
    }

    public async Task<List<Pizza>> GetAll()
    {
        return await context.Pizzas.ToListAsync();
    }
    public async Task<List<Pizza>> GetPizzasByIds(List<int> ids)
    {
        List<Pizza> pizzas = new List<Pizza>();
        foreach (int id in ids) 
        {
            pizzas.Add(await Get(id));
        }
        return pizzas;
    }
    public async Task<Pizza> Get(int id)
    {
        return await context.Pizzas.FindAsync(id);
    }


    public async Task<Pizza> Add(Pizza pizza)
    {
        context.Pizzas.Add(pizza);
        await context.SaveChangesAsync();
        return pizza;
    }
    public async Task<List<Pizza>> AddMultiple(List<Pizza> pizzas)
    {
        context.Pizzas.AddRange(pizzas);
        await context.SaveChangesAsync();
        return pizzas;
    }


    public async Task<Pizza> Delete(int id)
    {
        var pizza = await context.Pizzas.FindAsync(id);

        context.Pizzas.Remove(pizza);
        await context.SaveChangesAsync();
        return pizza;

    }

    public async Task<Pizza> Update(int id, Pizza pizza)
    {
        var existingPizza = await context.Pizzas.FindAsync(id);
        context.Pizzas.Update(existingPizza);
        await context.SaveChangesAsync();   
        return pizza;
    }
}