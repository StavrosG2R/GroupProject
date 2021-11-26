using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IFollowingRepository : IDisposable
    {
        IQueryable<Following> GetFollowings(string userId);
        Following GetFollowing(string followerId, string followeeId);
        void Add(Following following);
        void Remove(Following following);
    }
}
