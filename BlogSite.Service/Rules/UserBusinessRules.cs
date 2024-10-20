using BlogSite.DataAccess.Abstracts;
using Core.Exceptions;
using System.Text.RegularExpressions;

namespace BlogSite.Service.Rules;

public class UserBusinessRules(IUserRepository _userRepository)
{
  public async Task IsUserExistAsync(long id)
  {
    var user = await _userRepository.GetByIdAsync(id);

    if (user == null)
    {
      throw new NotFoundException($"{id} numaralı kullanıcı bulunamadı.");
    }
  }

  public async Task IsEmailUniqueAsync(string email)
  {
    var user = await _userRepository.GetByEmailAsync(email);
    
    if (user != null)
    {
      throw new ValidationException("Bu email ile sistemimizde zaten bir kullanıcı mevcut.");
    }
  }

  private const int MinimumLength = 6;

  public async Task IsPasswordValidAsync(string password)
  {

    if (string.IsNullOrEmpty(password) || password.Length < MinimumLength)
    {
      throw new ValidationException("Parola en az 6 karaktere sahip olmalıdır.");
    }

    var hasSpecialChar = new Regex(@"[!@#$%^&*(),.?""{}|<>]");

    if (!hasSpecialChar.IsMatch(password))
    {
      throw new ValidationException("Parola en az 1 özel karakter içermelidir.");
    }
  }
}
