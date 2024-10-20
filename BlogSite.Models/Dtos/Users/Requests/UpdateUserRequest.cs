namespace BlogSite.Models.Dtos.Users.Requests;

public sealed record UpdateUserRequest(long Id, string Email, string Username, string Password);
