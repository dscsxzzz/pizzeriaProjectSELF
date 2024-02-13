using COLORADO.Data.Models;
using COLORADO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Data.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    IUserInterface userService;
    public UserController(IUserInterface userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll() =>
    await userService.GetAll();

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await userService.Get(id);

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(User user)
    {
        var create = await userService.GetByUsername(user.username);
        if (create != null)
        {
            var errorMessage = new { message = "Username already taken" };
            return BadRequest(errorMessage);
        }
        create = await userService.GetByEmail(user.email);
        if (create != null)
        {
            var errorMessage = new { message = "Email already taken" };
            return BadRequest(errorMessage);
        }
        await userService.Add(user);
        var message = new {
            message = "Account created succesfully",
            status = "Ok"
        };
        return Ok(message);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Update(int id, User user)
    {
        if (id != user.id)
            return BadRequest();

        var existingUser = await userService.Get(id);
        if (existingUser is null)
        {
            return NotFound();
        }
        var create = await userService.GetByUsername(user.username);
        if (create != null && user.username != existingUser.username)
        {
            var errorMessage = new { message = "Username already taken" };
            return BadRequest(errorMessage);
        }
        create = await userService.GetByEmail(user.email);
        if (create != null && user.email != existingUser.email)
        {
            var errorMessage = new { message = "Email already taken" };
            return BadRequest(errorMessage);
        }

        User userMain = new User {
            id = user.id,
            username = user.username,
            password = existingUser.password,
            name = user.name,
            surname = user.surname,
            email = user.email,
            phone = user.phone,
            address = user.address
        };
        await userService.Update(id, userMain);

        return Ok(userMain);
    }
    

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> Delete(int id)
    {
        var pizza = await userService.Get(id);

        if (pizza is null)
            return NotFound();

        await userService.Delete(id);

        return NoContent();
    }
}
