using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IGpuRepository : IDisposable
    {
        IQueryable<GPU> GetAll();
        GPU GetById(int? ID);
        void Create(GPU gpu);
        void Update(GPU gpu);
        void Delete(int? ID);
    }
}
