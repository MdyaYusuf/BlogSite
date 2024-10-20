using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
  Task<ReturnModel<List<UserResponseDto>>> GetAllAsync();
  Task<ReturnModel<UserResponseDto?>> GetByIdAsync(long id);
  Task<ReturnModel<UserResponseDto>> AddAsync(CreateUserRequest request);
  Task<ReturnModel<UserResponseDto>> UpdateAsync(UpdateUserRequest request);
  Task<ReturnModel<UserResponseDto>> RemoveAsync(long id);
}
