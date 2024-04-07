using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Commands;

public record struct SignInUserCommand(SignInUserDto User) : IRequest<UserSignInResult>;