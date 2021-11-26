using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public IQueryable<Following> GetFollowings(string userId)
        {
            return _context.Followings
               .Where(a => a.FollowerId == userId);
        }

        public Following GetFollowing(string followerId, string followeeId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
        }

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
