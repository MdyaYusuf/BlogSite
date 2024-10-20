using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _categoryRepository;
  private readonly IMapper _mapper;
  private readonly CategoryBusinessRules _businessRules;
  public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules businessRules)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
    _businessRules = businessRules;
  }

  public async Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request)
  {
    try
    {
      await _businessRules.IsNameUnique(request.Name);

      Category createdCategory = _mapper.Map<Category>(request);
      await _categoryRepository.AddAsync(createdCategory);
      CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

      return new ReturnModel<CategoryResponseDto>()
      {
        Success = true,
        Message = "Kategori eklendi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.Created
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync()
  {
    try
    {
      List<Category> categories = await _categoryRepository.GetAllAsync();
      List<CategoryResponseDto> responseList = _mapper.Map<List<CategoryResponseDto>>(categories);

      return new ReturnModel<List<CategoryResponseDto>>()
      {
        Success = true,
        Message = "Kategori listesi başarılı bir şekilde getirildi.",
        Data = responseList,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<List<CategoryResponseDto>>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<List<CategoryResponseDto>>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<List<CategoryResponseDto>>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<CategoryResponseDto?>> GetByIdAsync(int id)
  {
    try
    {
      Category? category = await _categoryRepository.GetByIdAsync(id);
      CategoryResponseDto? response = _mapper.Map<CategoryResponseDto>(category);

      return new ReturnModel<CategoryResponseDto?>()
      {
        Success = true,
        Message = $"{id} numaralı kategori başarılı bir şekilde getirildi.",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CategoryResponseDto?>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CategoryResponseDto?>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CategoryResponseDto?>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<CategoryResponseDto>> RemoveAsync(int id)
  {
    try
    {
      await _businessRules.IsCategoryExistAsync(id);

      Category category = await _categoryRepository.GetByIdAsync(id);
      Category deletedCategory = await _categoryRepository.RemoveAsync(category);
      CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);

      return new ReturnModel<CategoryResponseDto>()
      {
        Success = true,
        Message = "Kategori başarılı bir şekilde silindi",
        Data = response,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
  }

  public async Task<ReturnModel<CategoryResponseDto>> UpdateAsync(UpdateCategoryRequest request)
  {
    try
    {
      await _businessRules.IsCategoryExistAsync(request.Id);

      Category existingCategory = await _categoryRepository.GetByIdAsync(request.Id);

      existingCategory.Id = existingCategory.Id;
      existingCategory.Name = request.Name;

      Category updatedCategory = await _categoryRepository.UpdateAsync(existingCategory);
      CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);

      return new ReturnModel<CategoryResponseDto>()
      {
        Success = true,
        Message = "Kategori güncellendi.",
        Data = dto,
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
    catch (NotFoundException ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
    catch (ValidationException ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
    catch (Exception ex)
    {
      return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
    }
  }
}
