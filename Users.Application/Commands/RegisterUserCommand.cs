using MediatR;
using Microsoft.AspNetCore.Identity;
using Users.Application.Dtos;

namespace Users.Application.Commands;

public sealed record RegisterUserCommand(UserRegistrationDto User) : IRequest<IdentityResult>;