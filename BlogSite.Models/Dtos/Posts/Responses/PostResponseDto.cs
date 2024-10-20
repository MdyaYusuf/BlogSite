namespace BlogSite.Models.Dtos.Posts.Responses;

public sealed record PostResponseDto
{
  public Guid Id { get; init; }
  public string Content { get; init; } = null!;
  public DateTime CreatedDate { get; init; }
  public string UserName { get; init; } = null!;
  public string Category { get; init; } = null!;
}
