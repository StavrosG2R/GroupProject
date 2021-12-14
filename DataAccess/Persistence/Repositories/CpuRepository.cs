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

        public CPU GetSocket(int ID)
        {
            var cpu = _context.CPUs.Find(ID);
            
            return _context.CPUs
                .SingleOrDefault(c => c.Socket == cpu.Socket);
        }
        public IQueryable<CPU> GetCPUsThatMatchTheSocket(string socketType)
        {
            if (socketType == null)
                throw new ArgumentNullException(nameof(socketType));

            IQueryable<CPU> filteredCpus = _context.CPUs.Include(m => m.Company).Where(m => m.Socket == socketType);

            return filteredCpus;
        }

        public IQueryable<CPU> GetCPU()
        {
            return _context.CPUs;
        }

        public IQueryable<CPU> GetAll()
        {
            return _context.CPUs;
        }

        public IQueryable<CPU> GetAllWithCompanies()
        {
            return _context.CPUs.Include(c => c.Company);
        }

        public CPU GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.CPUs
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
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
