using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IQueryable<Game> GetAll()
        {
            return _context.Games.Include(g => g.Company);
        }

        public Game GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Games
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
        }

        public void Create(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            _context.Games.Add(game);
        }

        public void Update(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            _context.Entry(game).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Game game =_context.Games.Find(ID);

            if (game == null)
                throw new Exception("Game not found");
            
            _context.Games.Remove(game);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
