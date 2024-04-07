using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Commands;
using Users.Application.Dtos;
using Users.Application.Queries;

namespace WebApplication1.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController(ISender mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        
        if (result.Succeeded)
        {
            return Ok(result);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(GetUsersQuery query)
    {
        var users = await mediator.Send(query);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser([FromQuery]GetUserQuery query)
    {
        var user = await mediator.Send(query);
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> EditUser([FromBody] EditUserCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{command}")]
    public async Task<IActionResult> DeleteUser([FromBody]DeleteUserCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}