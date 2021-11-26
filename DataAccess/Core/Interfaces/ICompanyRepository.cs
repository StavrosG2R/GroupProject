using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface ICompanyRepository : IDisposable
    {
        IQueryable<Company> GetAll();
        Company GetById(int? ID);
        void Add(Company company);
        void Update(Company company);
        void Delete(int? ID);
    }
}
