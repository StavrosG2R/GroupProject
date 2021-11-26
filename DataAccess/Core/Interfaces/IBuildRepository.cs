using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IBuildRepository : IDisposable
    {
        IQueryable<Build> GetAll();
        Build GetById(int? ID);
        void Add(Build build);
        void Update(Build build);
        void Delete(int? ID);
    }
}
