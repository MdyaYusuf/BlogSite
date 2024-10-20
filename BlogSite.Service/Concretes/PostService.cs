using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
  private readonly IPostRepository _postRepository;
  private readonly IMapper _mapper;
  private readonly PostBusinessRules _businessRules;
  public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
  {
    _postRepository = postRepository;
    _mapper = mapper;
    _businessRules = businessRules;
  }

  public async Task<ReturnModel<PostResponseDto>> AddAsync(CreatePostRequest request)
  {
    try
    {
      await _businessRules.IsTitleUnique(request.Title);

      Post createdPost = _mapper.Map<Post>(request);
      createdPost.Id = Guid.NewGuid();
      await _postRepository.AddAsync(createdPost);
      PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

      return new ReturnModel<PostResponseDto>()
      {
        Success = true,
        Message = "Post eklendi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.Created
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<List<PostResponseDto>>> GetAllAsync()
  {
    try
    {
      List<Post> posts = await _postRepository.GetAllAsync();
      List<PostResponseDto> responseList = _mapper.Map<List<PostResponseDto>>(posts);

      return new ReturnModel<List<PostResponseDto>>()
      {
        Success = true,
        Message = "Post listesi başarılı bir şekilde getirildi.",
        Data = responseList,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<List<PostResponseDto>>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<List<PostResponseDto>>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<List<PostResponseDto>>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<PostResponseDto?>> GetByIdAsync(Guid id)
  {
    try
    {
      var post = await _postRepository.GetByIdAsync(id);
      var response = _mapper.Map<PostResponseDto>(post);

      return new ReturnModel<PostResponseDto?>()
      {
        Success = true,
        Message = $"{id} numaralı post başarılı bir şekilde getirildi.",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<PostResponseDto?>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<PostResponseDto?>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<PostResponseDto?>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<PostResponseDto>> RemoveAsync(Guid id)
  {
    try
    {
      await _businessRules.IsPostExistsAsync(id);

      Post post = await _postRepository.GetByIdAsync(id);
      Post deletedPost = await _postRepository.RemoveAsync(post);
      PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

      return new ReturnModel<PostResponseDto>()
      {
        Success = true,
        Message = $"Post silindi.",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<PostResponseDto>> UpdateAsync(UpdatePostRequest request)
  {
    try
    {
      await _businessRules.IsPostExistsAsync(request.Id);

      Post existingPost = await _postRepository.GetByIdAsync(request.Id);

      existingPost.CategoryId = existingPost.CategoryId;
      existingPost.Content = request.Content;
      existingPost.Title = request.Title;
      existingPost.AuthorId = existingPost.AuthorId;
      existingPost.CreatedDate = existingPost.CreatedDate;

      Post updatedPost = await _postRepository.UpdateAsync(existingPost);
      PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);

      return new ReturnModel<PostResponseDto>()
      {
        Success = true,
        Message = $"Post güncellendi.",
        Data = dto,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<PostResponseDto>.HandleException(ex);
    }
  }
}
