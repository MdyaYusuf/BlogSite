using Core.Entities;

namespace BlogSite.Models.Entities;

public sealed class Category : Entity<int>
{
  public Category()
  {
    
  }
  public Category(string name)
  {
    Name = name;
  }

  public string Name { get; set; } = string.Empty;
  public List<Post>? Posts { get; set; }
}
