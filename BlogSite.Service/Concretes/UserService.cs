using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
  public UserService(IUserRepository userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task<ReturnModel<UserResponseDto>> AddAsync(CreateUserRequest request)
  {
    try
    {
      User createdUser = _mapper.Map<User>(request);
      await _userRepository.AddAsync(createdUser);
      UserResponseDto response = _mapper.Map<UserResponseDto>(createdUser);

      return new ReturnModel<UserResponseDto>()
      {
        Success = true,
        Message = "Kulanıcı eklendi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.Created
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<List<UserResponseDto>>> GetAllAsync()
  {
    try
    {
      List<User> users = await _userRepository.GetAllAsync();
      List<UserResponseDto> responseList = _mapper.Map<List<UserResponseDto>>(users);

      return new ReturnModel<List<UserResponseDto>>()
      {
        Success = true,
        Message = "Kullanıcı listesi başarılı bir şekilde getirildi.",
        Data = responseList,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<List<UserResponseDto>>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<List<UserResponseDto>>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<List<UserResponseDto>>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<UserResponseDto?>> GetByIdAsync(long id)
  {
    try
    {
      User? user = await _userRepository.GetByIdAsync(id);
      UserResponseDto? response = _mapper.Map<UserResponseDto>(user);

      return new ReturnModel<UserResponseDto?>()
      {
        Success = true,
        Message = $"{id} numaralı kullanıcı başarılı bir şekilde getirildi.",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<UserResponseDto?>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<UserResponseDto?>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<UserResponseDto?>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<UserResponseDto>> RemoveAsync(long id)
  {
    try
    {
      User user = await _userRepository.GetByIdAsync(id);
      User deletedUser = await _userRepository.RemoveAsync(user);
      UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);

      return new ReturnModel<UserResponseDto>()
      {
        Success = true,
        Message = "Kullanıcı başarılı bir şekilde silindi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<UserResponseDto>> UpdateAsync(UpdateUserRequest request)
  {
    try
    {
      User existingUser = await _userRepository.GetByIdAsync(request.Id);

      existingUser.Id = existingUser.Id;
      existingUser.FirstName = existingUser.FirstName;
      existingUser.LastName = existingUser.LastName;
      existingUser.Email = request.Email;
      existingUser.Username = request.Username;
      existingUser.Password = request.Password;

      User updatedUser = await _userRepository.UpdateAsync(existingUser);
      UserResponseDto dto = _mapper.Map<UserResponseDto>(updatedUser);

      return new ReturnModel<UserResponseDto>()
      {
        Success = true,
        Message = "Kullanıcı güncellendi.",
        Data = dto,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<UserResponseDto>.HandleException(ex);
    }
  }
}
