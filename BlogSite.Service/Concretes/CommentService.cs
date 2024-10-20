using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CommentService : ICommentService
{
  private readonly ICommentRepository _commentRepository;
  private readonly IMapper _mapper;
  private readonly CommentBusinessRules _businessRules;
  public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules businessRules)
  {
    _commentRepository = commentRepository;
    _mapper = mapper;
    _businessRules = businessRules;
  }

  public async Task<ReturnModel<CommentResponseDto>> AddAsync(CreateCommentRequest request)
  {
    try
    {
      Comment createdComment = _mapper.Map<Comment>(request);
      await _commentRepository.AddAsync(createdComment);
      CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);

      return new ReturnModel<CommentResponseDto>()
      {
        Success = true,
        Message = "Yorum eklendi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.Created
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<List<CommentResponseDto>>> GetAllAsync()
  {
    try
    {
      List<Comment> comments = await _commentRepository.GetAllAsync();
      List<CommentResponseDto> responseList = _mapper.Map<List<CommentResponseDto>>(comments);

      return new ReturnModel<List<CommentResponseDto>>()
      {
        Success = true,
        Message = "Yorum listesi başarılı bir şekilde getirildi.",
        Data = responseList,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<List<CommentResponseDto>>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<List<CommentResponseDto>>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<List<CommentResponseDto>>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<CommentResponseDto?>> GetByIdAsync(Guid id)
  {
    try
    {
      Comment? comment = await _commentRepository.GetByIdAsync(id);
      CommentResponseDto? response = _mapper.Map<CommentResponseDto>(comment);

      return new ReturnModel<CommentResponseDto?>()
      {
        Success = true,
        Message = $"{id} numaralı yorum başarılı bir şekilde getirildi.",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CommentResponseDto?>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CommentResponseDto?>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CommentResponseDto?>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<CommentResponseDto>> RemoveAsync(Guid id)
  {
    try
    {
      await _businessRules.IsCommentExistAsync(id);

      Comment comment = await _commentRepository.GetByIdAsync(id);
      Comment deletedComment = await _commentRepository.RemoveAsync(comment);
      CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedComment);

      return new ReturnModel<CommentResponseDto>()
      {
        Success = true,
        Message = "Yorum başarılı bir şekilde silindi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<CommentResponseDto>> UpdateAsync(UpdateCommentRequest request)
  {
    try
    {
      await _businessRules.IsCommentExistAsync(request.Id);

      Comment existingComment = await _commentRepository.GetByIdAsync(request.Id);

      existingComment.Id = existingComment.Id;
      existingComment.Text = request.Text;

      Comment updatedComment = await _commentRepository.UpdateAsync(existingComment);
      CommentResponseDto dto = _mapper.Map<CommentResponseDto>(updatedComment);

      return new ReturnModel<CommentResponseDto>()
      {
        Success = true,
        Message = "Yorum güncellendi.",
        Data = dto,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CommentResponseDto>.HandleException(ex);
    }
  }
}
