using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICommentService
{
  Task<ReturnModel<List<CommentResponseDto>>> GetAllAsync();
  Task<ReturnModel<CommentResponseDto?>> GetByIdAsync(Guid id);
  Task<ReturnModel<CommentResponseDto>> AddAsync(CreateCommentRequest request);
  Task<ReturnModel<CommentResponseDto>> UpdateAsync(UpdateCommentRequest request);
  Task<ReturnModel<CommentResponseDto>> RemoveAsync(Guid id);
}
