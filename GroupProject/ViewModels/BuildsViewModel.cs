using DataAccess.Core.Entities;
using System.Linq;

namespace GroupProject.ViewModels
{
    public class BuildsViewModel
    {
        public IQueryable<Build> Builds { get; set; }
        public string SearchBar { get; set; }
        public ILookup<string, Following> Followings { get; set; }
    }
}