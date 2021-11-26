using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface ICommentRepository : IDisposable
    {
        IQueryable<Comment> GetAll();
        Comment GetById(int? ID);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int? ID);
    }
}
