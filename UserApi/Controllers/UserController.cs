using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Dtos;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    TokenService tokenService)
    : ControllerBase
{
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(UserRegistrationDto userDto)
    {
        var user = new User
        {
            UserName = userDto.Email,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName
        };

        var result = await userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
        {
            return Ok(new UserDto(user.Id, user.Email, user.FirstName, user.LastName));
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return Unauthorized();
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized();
        }

        var token = tokenService.GenerateToken(user.Id, user.Email);
        return Ok(new { Token = token });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditUser(string id, [FromBody] UserDto userDto)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Email = userDto.Email;
        user.UserName = userDto.Email;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok(new UserDto(user.Id, user.Email, user.FirstName, user.LastName));
        }

        return BadRequest(result.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var result = await userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest(result.Errors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(new UserDto(user.Id, user.Email, user.FirstName, user.LastName));
    }
}
