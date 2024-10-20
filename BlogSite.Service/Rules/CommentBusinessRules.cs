using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using Core.Exceptions;

namespace BlogSite.Service.Rules;

public class CommentBusinessRules(ICommentRepository _commentRepository)
{
  public async Task IsCommentExistAsync(Guid id)
  {
    var comment = await _commentRepository.GetByIdAsync(id);

    if (comment == null)
    {
      throw new NotFoundException($"{id} numaralı yorum bulunamadı.");
    }
  }
}
