namespace BlogSite.Models.Dtos.Users.Responses;

public sealed record UserResponseDto
{
  public string FirstName { get; init; } = null!;
  public string LastName { get; init; } = null!;
  public string Email { get; init; } = null!;
  public string UserName { get; init; } = null!;
}
