using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetBuildersFollowedBy(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }
    }
}
