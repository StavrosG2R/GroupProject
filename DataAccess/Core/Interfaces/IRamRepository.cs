using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IRamRepository : IDisposable
    {
        IQueryable<RAM> GetAll();
        RAM GetById(int? ID);
        void Create(RAM ram);
        void Update(RAM ram);
        void Delete(int? ID);
    }
}
