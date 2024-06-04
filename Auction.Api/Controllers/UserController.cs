using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using Auction.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public UserController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDto)
    {
        var userApiUrl = _configuration["UserApi:BaseUrl"] + "/api/users/register";
        var jsonContent = new StringContent(JsonSerializer.Serialize(userDto), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(userApiUrl, jsonContent);
        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserDto>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Ok(user);
        }

        return BadRequest("User registration failed.");
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        var userApiUrl = _configuration["UserApi:BaseUrl"] + "/api/users/login";
        var jsonContent = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(userApiUrl, jsonContent);
        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            return Ok(JsonSerializer.Deserialize<JsonElement>(responseData));
        }

        return Unauthorized("Login failed.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var userApiUrl = _configuration["UserApi:BaseUrl"] + $"/api/users/{id}";
        var response = await _httpClient.GetAsync(userApiUrl);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserDto>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Ok(user);
        }

        return NotFound("User not found.");
    }
}