using Core.Entities;

namespace BlogSite.Models.Entities;

public class User : Entity<long>
{
  public User()
  {
        
  }
  public User(string firstName, string lastName, string email, string username, string password)
  {
    FirstName = firstName;
    LastName = lastName;
    Email = email;
    Username = username;
    Password = password;
  }

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public List<Post>? Posts { get; set; }
  public List<Comment>? Comments { get; set; }
}
