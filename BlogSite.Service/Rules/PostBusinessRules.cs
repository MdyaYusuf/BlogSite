using Azure.Core;
using BlogSite.DataAccess.Abstracts;
using Core.Exceptions;

namespace BlogSite.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
  public async Task IsPostExistsAsync(Guid id)
  {
    var post = await _postRepository.GetByIdAsync(id);

    if (post == null)
    {
      throw new NotFoundException($"{id} numaralı post bulunamadı.");
    }
  }

  public async Task IsTitleUnique(string title)
  {
    var existingPost = await _postRepository.GetByTitleAsync(title);

    if (existingPost != null)
    {
      throw new ValidationException("Bu başlık ile sistemimizde zaten bir post mevcut.");
    }
  }
}
