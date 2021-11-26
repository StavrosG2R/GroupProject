using DataAccess.Core.Entities;
using System.Collections.Generic;

namespace DataAccess.Core.Interfaces
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetBuildersFollowedBy(string userId);
    }
}
