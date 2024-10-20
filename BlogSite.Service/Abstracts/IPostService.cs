﻿using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IPostService
{
  Task<ReturnModel<List<PostResponseDto>>> GetAllAsync();
  Task<ReturnModel<PostResponseDto?>> GetByIdAsync(Guid id);
  Task<ReturnModel<PostResponseDto>> AddAsync(CreatePostRequest request);
  Task<ReturnModel<PostResponseDto>> UpdateAsync(UpdatePostRequest request);
  Task<ReturnModel<PostResponseDto>> RemoveAsync(Guid id);
}