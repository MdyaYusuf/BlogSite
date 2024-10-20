namespace BlogSite.Models.Dtos.Comments.Responses;

public sealed record CommentResponseDto
{
  public Guid Id { get; init; }
  public string Text { get; init; } = null!;
}
