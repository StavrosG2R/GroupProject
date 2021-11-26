using DataAccess.Core.Interfaces;
using DataAccess.Persistence.Repositories;

namespace DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IApplicationUserRepository Users { get; private set; }

        public IBuildRepository Builds { get; private set; }

        public ICaseRepository Cases { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ICommentRepository Comments { get; private set; }

        public ICompanyRepository Companies { get; private set; }

        public ICpuRepository Cpus { get; private set; }

        public IFollowingRepository Followings { get; private set; }

        public IGameRepository Games { get; private set; }

        public IGpuRepository Gpus { get; private set; }

        public IMotherboardRepository Motherboards { get; private set; }

        public IPsuRepository Psus { get; private set; }

        public IRamRepository Rams { get; private set; }

        public IStorageRepository Storages { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new ApplicationUserRepository(_context);
            Builds = new BuildRepository(_context);
            Cases = new CaseRepository(_context);
            Categories = new CategoryRepository(_context);
            Comments = new CommentRepository(_context);
            Companies = new CompanyRepository(_context);
            Cpus = new CpuRepository(_context);
            Followings = new FollowingRepository(_context);
            Games = new GameRepository(_context);
            Gpus = new GpuRepository(_context);
            Motherboards = new MotherboardRepository(_context);
            Psus = new PsuRepository(_context);
            Rams = new RamRepository(_context);
            Storages = new StorageRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
