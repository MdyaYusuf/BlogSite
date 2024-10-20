using AutoMapper;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Profiles;

public class MappingProfiles : Profile
{
  // Auto mapper için dönüşüm yapacağımız ilgili alanların isimleri aynı olmalı.
  public MappingProfiles()
  {
    CreateMap<CreatePostRequest, Post>();
    CreateMap<UpdatePostRequest, Post>();
    CreateMap<Post, PostResponseDto>()
      .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category.Name))
      .ForMember(p => p.UserName, opt => opt.MapFrom(p => p.Author.Username));

    CreateMap<CreateUserRequest, User>();
    CreateMap<UpdateUserRequest, User>();
    CreateMap<User, UserResponseDto>();

    CreateMap<CreateCommentRequest, Comment>();
    CreateMap<UpdateCommentRequest, Comment>();
    CreateMap<Comment, CommentResponseDto>();

    CreateMap<CreateCategoryRequest, Category>();
    CreateMap<UpdateCategoryRequest, Category>();
    CreateMap<Category, CategoryResponseDto>();
  }
}
