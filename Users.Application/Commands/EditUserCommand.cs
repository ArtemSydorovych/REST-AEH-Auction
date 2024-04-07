using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Commands;

public class EditUserCommand(UserDto User) : IRequest;