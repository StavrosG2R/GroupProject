using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly ApplicationDbContext _context;

        public StorageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Storage> GetAll()
        {
            return _context.Storages.Include(s => s.Company);
        }

        public Storage GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Storages
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
        }

        public void Create(Storage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));

            _context.Storages.Add(storage);
        }

        public void Update(Storage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));

            _context.Entry(storage).State= EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Storage storage = _context.Storages.Find(ID);

            if (storage == null)
                throw new Exception("Storage not found");

            _context.Storages.Remove(storage);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
