using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface ICategoryRepository : IDisposable
    {
        IQueryable<Category> GetAll();
        Category GetById(int? ID);
        void Add(Category category);
        void Update(Category category);
        void Delete(int? ID);
    }
}
