using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Comment> GetAll()
        {

            return _context.Comments;
        }

        public Comment GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Comments.Find(ID);
        }

        public void Add(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Comment comment = _context.Comments.Find(ID);

            if (comment == null)
                throw new Exception("Comment not found");

            _context.Comments.Remove(comment);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
