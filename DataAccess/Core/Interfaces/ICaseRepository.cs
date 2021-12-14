using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface ICaseRepository : IDisposable
    {
        IQueryable<Case> GetAll();
        Case GetById(int? ID);
        void Create(Case cases); // to case baraei
        void Update(Case cases); // to case baraei
        void Delete(int? ID);
    }
}
