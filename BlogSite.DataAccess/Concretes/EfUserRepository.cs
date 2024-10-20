using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.DataAccess.Concretes;

public class EfUserRepository : EfBaseRepository<BaseDbContext, User, long>, IUserRepository
{
  public EfUserRepository(BaseDbContext context) : base(context)
  {

  }

  public async Task<User?> GetByEmailAsync(string email)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
  }
}
