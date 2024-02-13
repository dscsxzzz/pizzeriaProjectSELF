using COLORADO.Data.Models;
using COLORADO.Services;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Data.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService pizzaService;
    public PizzaController(IPizzaService pizzaService)
    {
        this.pizzaService = pizzaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> GetAll()
    {
        return Ok(await pizzaService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await pizzaService.Get(id);

        if (pizza == null)
            return NotFound();

        return Ok(pizza);
    }

    [HttpGet("multiplePizzas")]
    public async Task<ActionResult<List<Pizza>>> GetPizzasByIds([FromQuery]List<int> ids)
    {
        return Ok(await pizzaService.GetPizzasByIds(ids));
    }

    [HttpPost]
    public async Task<ActionResult<Pizza>> Create(Pizza pizza)
    {
        return Ok(await pizzaService.Add(pizza));
    }
    [HttpPost("multiple")]
    public async Task<ActionResult<List<Pizza>>> AddMultiple(List<Pizza> pizzas)
    {
        return Ok(await pizzaService.AddMultiple(pizzas));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Pizza>> Update(int id, Pizza pizza)
    {
        if (id != pizza.id)
            return BadRequest();

        var existingPizza = await pizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();


        return Ok(await pizzaService.Update(id, pizza));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Pizza>> Delete(int id)
    {
        var pizza = await pizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        pizza = await pizzaService.Delete(id);

        return Ok(pizza);
    }
}