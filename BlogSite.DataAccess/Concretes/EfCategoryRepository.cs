using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.DataAccess.Concretes;

public class EfCategoryRepository : EfBaseRepository<BaseDbContext, Category, int>, ICategoryRepository
{
  public EfCategoryRepository(BaseDbContext context) : base(context)
  {
        
  }

  public async Task<Category?> GetByNameAsync(string name)
  {
    return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
  }
}
