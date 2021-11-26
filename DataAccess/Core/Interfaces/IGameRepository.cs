using DataAccess.Core.Entities;
using System;
using System.Linq;

namespace DataAccess.Core.Interfaces
{
    public interface IGameRepository : IDisposable
    {
        IQueryable<Game> GetAll();
        Game GetById(int? ID);
        void Create(Game game);
        void Update(Game game);
        void Delete(int? ID);
    }
}
