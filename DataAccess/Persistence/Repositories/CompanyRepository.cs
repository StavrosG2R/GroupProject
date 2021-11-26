using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies;
        }

        public Company GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Companies.Find(ID);
        }

        public void Add(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            _context.Companies.Add(company);
        }

        public void Update(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            _context.Entry(company).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Company company = _context.Companies.Find(ID);

            if (company == null)
                throw new ArgumentNullException(nameof(company));

            _context.Companies.Remove(company);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
