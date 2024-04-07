namespace Users.Application.Dtos;

public sealed record UserSignInResult(bool Succeeded, string? Token,  IEnumerable<string> Errors);