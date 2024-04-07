using MediatR;

namespace Users.Application.Commands;

public class DeleteUserCommand(Guid UserId) : IRequest;