using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class BuildRepository : IBuildRepository
    {
        private readonly ApplicationDbContext _context;
        public BuildRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Build> GetAll()
        {
            return _context.Builds
                .Include(b => b.Builder)
                .Include(b => b.Case)
                .Include(b => b.Category)
                .Include(b => b.CPU)
                .Include(b => b.GPU)
                .Include(b => b.Motherboard)
                .Include(b => b.PSU)
                .Include(b => b.RAM)
                .Include(b => b.Storage);
        }
        public Build GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Builds.Find(ID);
        }
        public void Add(Build build)
        {
            if (build == null)
                throw new ArgumentNullException(nameof(build));

            _context.Builds.Add(build);
        }
        public void Update(Build build)
        {
            if (build == null)
                throw new ArgumentNullException(nameof(build));

            _context.Entry(build).State = EntityState.Modified;
        }
        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Build build = _context.Builds.Find(ID);

            if(build == null)
                throw new Exception("Build not found");

            _context.Builds.Remove(build);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
