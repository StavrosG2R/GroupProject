using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IPsuRepository : IDisposable
    {
        IQueryable<PSU> GetAll();
        PSU GetById(int? ID);
        void Create(PSU psu);
        void Update(PSU psu);
        void Delete(int? ID);
    }
}
