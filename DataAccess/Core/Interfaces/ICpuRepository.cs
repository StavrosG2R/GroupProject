using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface ICpuRepository : IDisposable
    {
        IQueryable<CPU> GetAllWithCompanies();
        IQueryable<CPU> GetCPUsThatMatchTheSocket(string socketType);
        IQueryable<CPU> GetAll();
        IQueryable<CPU> GetCPU();
        CPU GetById(int? ID);
        void Create(CPU cpu);
        void Update(CPU cpu);
        void Delete(int? ID);
        CPU GetSocket(int ID);
        IQueryable<CPU> GetAllWithCompanies();
        IQueryable<CPU> GetCPUsThatMatchTheSocket(string socketType);
    }
}
