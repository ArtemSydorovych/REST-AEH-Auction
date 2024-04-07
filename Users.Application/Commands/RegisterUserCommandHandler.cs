using MediatR;
using Microsoft.AspNetCore.Identity;
using Users.Domain.Entities;
using Users.Domain.Interfaces;

namespace Users.Application.Commands;

public class RegisterUserCommandHandler(UserManager<User> userManager) : IRequestHandler<RegisterUserCommand, IdentityResult>
{
    public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.User.Email,
            Email = request.User.Email,
            FirstName = request.User.FirstName,
            LastName = request.User.LastName
        };

        var result = await userManager.CreateAsync(user, request.User.Password);
        return result;
    }
}