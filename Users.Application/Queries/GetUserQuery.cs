using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Queries;

public class GetUserQuery(Guid Id) : IRequest<UserDto>;