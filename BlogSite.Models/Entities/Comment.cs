using Core.Entities;

namespace BlogSite.Models.Entities;

public class Comment : Entity<Guid>
{
  public Comment()
  {
      
  }
  public Comment(string text, Guid postId, Post post, long userId, User user)
  {
    Text = text;
    PostId = postId;
    Post = post;
    UserId = userId;
    User = user;
  }

  public string Text { get; set; } = string.Empty;
  public Guid PostId { get; set; }
  public Post Post { get; set; } = null!;
  public long UserId { get; set; }
  public User User { get; set; } = null!;
}
