using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
  Task<Category?> GetByNameAsync(string name);
}
