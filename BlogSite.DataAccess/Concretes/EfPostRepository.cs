using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.DataAccess.Concretes;

public class EfPostRepository : EfBaseRepository<BaseDbContext, Post, Guid>, IPostRepository
{
  public EfPostRepository(BaseDbContext context) : base(context)
  {

  }

  public async Task<Post?> GetByTitleAsync(string title)
  {
    return await _context.Posts.FirstOrDefaultAsync(p => p.Title == title);
  }
}