using DataAccess.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetBuildersFollowedBy(string userId);
        IQueryable<ApplicationUser> GetAll();
        ApplicationUser GetById(string userId);
    }
}
