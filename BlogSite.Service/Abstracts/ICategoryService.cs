using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
  Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync();
  Task<ReturnModel<CategoryResponseDto?>> GetByIdAsync(int id);
  Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request);
  Task<ReturnModel<CategoryResponseDto>> UpdateAsync(UpdateCategoryRequest request);
  Task<ReturnModel<CategoryResponseDto>> RemoveAsync(int id);
}
