using COLORADO.Data.Models;
using COLORADO.Services;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Data.Controllers;

[ApiController]
[Route("[controller]")]
public class DessertController : ControllerBase
{
    IDessertInterface dessertService;
    public DessertController(IDessertInterface dessertService)
    {
        this.dessertService = dessertService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Dessert>>> GetAll()
    {
        return Ok(await dessertService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dessert>> Get(int id)
    {
        var Dessert = await dessertService.Get(id);

        if (Dessert == null)
            return NotFound();

        return Ok(Dessert);
    }

    [HttpPost]
    public async Task<ActionResult<Dessert>> Create(Dessert dessert)
    {
        await dessertService.Add(dessert);
        return Ok(dessert);
    }
    [HttpPost("multiple")]
    public async Task<ActionResult<List<Dessert>>> AddMultiple(List<Dessert> desserts)
    {
        return Ok(await dessertService.AddMultiple(desserts));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Dessert>> Update(int id, Dessert dessert)
    {
        if (id != dessert.id)
            return BadRequest();

        var existingDessert = await dessertService.Get(id);
        if (existingDessert is null)
            return NotFound();

        existingDessert = await dessertService.Update(id, dessert);
        if (existingDessert is null)
        {
            return NotFound();
        }
        return Ok(existingDessert);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Dessert>> Delete(int id)
    {
        var Dessert = await dessertService.Get(id);

        if (Dessert is null)
            return NotFound();

        Dessert = await dessertService.Delete(id);

        return Ok(Dessert);
    }
}