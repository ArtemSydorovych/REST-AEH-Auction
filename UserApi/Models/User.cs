using Microsoft.AspNetCore.Identity;

namespace UserApi.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
