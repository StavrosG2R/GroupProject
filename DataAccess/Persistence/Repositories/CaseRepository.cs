using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly ApplicationDbContext _context;
        public CaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Case> GetAll()
        {
            return _context.Cases.Include(c => c.Company);
        }
        public Case GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Cases.Find(ID);
        }
        public void Create(Case cases)
        {
            if (cases == null)
                throw new ArgumentNullException(nameof(cases));

            _context.Cases.Add(cases);
        }
        public void Update(Case cases)
        {
            if (cases == null)
                throw new ArgumentNullException(nameof(cases));

            _context.Entry(cases).State = EntityState.Modified;
        }
        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Case cases = _context.Cases.Find(ID);

            if (cases == null)
                throw new Exception("Case not found");

            _context.Cases.Remove(cases);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
