using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class RamRepository : IRamRepository
    {
        private readonly ApplicationDbContext _context;

        public RamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<RAM> GetAll()
        {
            return _context.RAMs.Include(r => r.Company);
        }

        public RAM GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.RAMs
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
        }

        public void Create(RAM ram)
        {
            if (ram == null)
                throw new ArgumentNullException(nameof(ram));

            _context.RAMs.Add(ram);
        }

        public void Update(RAM ram)
        {
            if (ram == null)
                throw new ArgumentNullException(nameof(ram));

            _context.Entry(ram).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            RAM ram = _context.RAMs.Find(ID);

            if (ram == null)
                throw new Exception("Ram not found");

            _context.RAMs.Remove(ram);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
