using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class PsuRepository : IPsuRepository
    {
        private readonly ApplicationDbContext _context;

        public PsuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<PSU> GetAll()
        {
            return _context.PSUs.Include(p => p.Company);
        }

        public PSU GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.PSUs
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
        }

        public void Create(PSU psu)
        {
            if (psu == null)
                throw new ArgumentNullException(nameof(psu));

            _context.PSUs.Add(psu);
        }

        public void Update(PSU psu)
        {
            if (psu == null)
                throw new ArgumentNullException(nameof(psu));

            _context.Entry(psu).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            PSU psu = _context.PSUs.Find(ID);

            if (psu == null)
                throw new Exception("Psu not found");

            _context.PSUs.Remove(psu);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
