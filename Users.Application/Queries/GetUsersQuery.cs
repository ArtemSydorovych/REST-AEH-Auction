using MediatR;
using Users.Application.Dtos;
using Users.Domain.Entities;

namespace Users.Application.Queries;

public class GetUsersQuery : IRequest<IEnumerable<UserDto>>;