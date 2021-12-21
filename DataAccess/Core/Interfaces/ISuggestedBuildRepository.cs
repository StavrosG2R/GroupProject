using DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Interfaces
{
    public interface ISuggestedBuildRepository : IDisposable
    {
        IQueryable<SuggestedBuild> GetAll();
        SuggestedBuild GetById(int? ID);
        void Add(SuggestedBuild suggestedBuild);
        void Update(SuggestedBuild suggestedBuild);
        void Delete(int? ID);
    }
}
