using System;

namespace DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository Users { get; }
        IBuildRepository Builds { get; }
        ICaseRepository Cases { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        ICompanyRepository Companies { get; }
        ICpuRepository Cpus { get; }
        IFollowingRepository Followings { get; }
        IGameRepository Games { get; }
        IGpuRepository Gpus { get; }
        IMotherboardRepository Motherboards { get; }
        IPsuRepository Psus { get; }
        IRamRepository Rams { get; }
        IStorageRepository Storages { get; }
        ISuggestedBuildRepository SuggestedBuilds { get;}
        void Complete();
    }
}
