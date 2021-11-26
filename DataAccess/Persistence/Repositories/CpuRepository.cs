using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CpuRepository : ICpuRepository
    {
        private readonly ApplicationDbContext _context;

        public CpuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CPU> GetAll()
        {
            return _context.CPUs;
        }

        public CPU GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.CPUs.Find(ID);
        }

        public void Create(CPU cpu)
        {
            if (cpu == null)
                throw new ArgumentNullException(nameof(cpu));

            _context.CPUs.Add(cpu);
        }

        public void Update(CPU cpu)
        {
            if (cpu == null)
                throw new ArgumentNullException(nameof(cpu));

            _context.Entry(cpu).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            CPU cpu = _context.CPUs.Find(ID);

            if (cpu == null)
                throw new ArgumentNullException(nameof(cpu));

            _context.CPUs.Remove(cpu);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
