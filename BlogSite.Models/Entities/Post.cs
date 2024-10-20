using Core.Entities;

namespace BlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{
  public Post()
  {
        
  }
  public Post(string title, string content, int categoryId, Category category, int authorId, User author)
  {
    Title = title;
    Content = content;
    CategoryId = categoryId;
    Category = category;
    AuthorId = authorId;
    Author = author;
  }

  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public int CategoryId { get; set; }
  public Category Category { get; set; } = null!;
  public long AuthorId { get; set; }
  public User Author { get; set; } = null!;
  public List<Comment>? Comments { get; set; }
}
