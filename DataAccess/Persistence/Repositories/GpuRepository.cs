using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class GpuRepository : IGpuRepository
    {
        private readonly ApplicationDbContext _context;

        public GpuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<GPU> GetAll()
        {
            return _context.GPUs.Include(g => g.Company);
        }

        public GPU GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.GPUs
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
        }

        public void Create(GPU gpu)
        {
            if (gpu == null)
                throw new ArgumentNullException(nameof(gpu));

            _context.GPUs.Add(gpu);
        }

        public void Update(GPU gpu)
        {
            if (gpu == null)
                throw new ArgumentNullException(nameof(gpu));

            _context.Entry(gpu).State=EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            GPU gpu = _context.GPUs.Find(ID);

            if (gpu == null)
                throw new Exception("Gpu not found");

            _context.GPUs.Remove(gpu);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
