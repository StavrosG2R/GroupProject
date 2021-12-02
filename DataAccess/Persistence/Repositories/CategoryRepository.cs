using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Categories.Find(ID);
        }
        
        public void Add(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _context.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Category category = _context.Categories.Find(ID);

            if (category == null)
                throw new Exception("Category not found");

            _context.Categories.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
