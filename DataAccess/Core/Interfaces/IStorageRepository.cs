using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IStorageRepository : IDisposable
    {
        IQueryable<Storage> GetAll();
        Storage GetById(int? ID);
        void Create(Storage storage);
        void Update(Storage storage);
        void Delete(int? ID);
    }
}
