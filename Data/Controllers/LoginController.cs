using COLORADO.Data.Models;
using COLORADO.Services;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Data.Controllers;
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    IUserInterface userService;
    public LoginController(IUserInterface userService) {
    this.userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Check(User user)
    {
        var create = await userService.GetByUsername(user.username);

        if (create != null)
        {
            if (user.password != create.password) {
                return BadRequest();
            }
        } else
        {
            create = await userService.GetByEmail(user.email);
            if (create != null)
            {
                if (user.password != create.password)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

        }
        return Ok(create);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Update(int id, User user)
    {
        if (id != user.id)
            return BadRequest();

        var existinguser = await userService.Get(id);
        if (existinguser is null)
            return NotFound();

        existinguser = await userService.Update(id, user);

        return Ok(existinguser);
    }

}
