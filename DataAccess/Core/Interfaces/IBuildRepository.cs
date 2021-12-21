using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IBuildRepository : IDisposable
    {
        IQueryable<Build> MyBuilds(string userId);
        IQueryable<Build> GetAll();
        Build GetById(int? ID);
        void Add(Build build);
        void Update(Build build);
        void Delete(int? ID);
        IQueryable<Build> SearchBuilds(string SearchBar = null);
    }
}
