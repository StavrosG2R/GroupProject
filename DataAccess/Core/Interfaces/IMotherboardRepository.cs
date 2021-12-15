using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IMotherboardRepository : IDisposable
    {
        IQueryable<Motherboard> GetAllWithCompanies();
        IQueryable<Motherboard> GetAll();
        Motherboard GetById(int? ID);
        void Create(Motherboard motherboard);
        void Update(Motherboard motherboard);
        void Delete(int? ID);
        IQueryable<Motherboard> GetMotherboardsThatMatchTheSocket(string socketType);
    }
}
