namespace Users.Application.Dtos;

public sealed record RegisteredUserDto(Guid Id, string Email, string FirstName, string LastName);