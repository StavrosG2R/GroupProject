using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Repositories
{
    public class SuggestedBuildRepository : ISuggestedBuildRepository
    {
        private readonly ApplicationDbContext _context;
        public SuggestedBuildRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<SuggestedBuild> GetAll()
        {
            return _context.SuggestedBuilds
                .Include(b => b.Case)
                .Include(b => b.Category)
                .Include(b => b.CPU)
                .Include(b => b.GPU)
                .Include(b => b.Motherboard)
                .Include(b => b.PSU)
                .Include(b => b.RAM)
                .Include(b => b.Storage);
        }

        public SuggestedBuild GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.SuggestedBuilds
                .Include(b => b.Case)
                .Include(b => b.Category)
                .Include(b => b.CPU)
                .Include(b => b.GPU)
                .Include(b => b.Motherboard)
                .Include(b => b.PSU)
                .Include(b => b.RAM)
                .Include(b => b.Storage)
                .FirstOrDefault(b => b.ID == ID);
        }
        public void Add(SuggestedBuild suggestedBuild)
        {
            if (suggestedBuild == null)
                throw new ArgumentNullException(nameof(suggestedBuild));

            _context.SuggestedBuilds.Add(suggestedBuild);
        }
        public void Update(SuggestedBuild suggestedBuild)
        {
            if (suggestedBuild == null)
                throw new ArgumentNullException(nameof(suggestedBuild));

            _context.Entry(suggestedBuild).State = EntityState.Modified;
        }
        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            SuggestedBuild suggestedBuild = _context.SuggestedBuilds.Find(ID);

            if (suggestedBuild == null)
                throw new Exception("Build not found");

            _context.SuggestedBuilds.Remove(suggestedBuild);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        
    }
}
