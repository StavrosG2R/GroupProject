using DataAccess.Core.Entities;
using System.Linq;

namespace GroupProject.ViewModels
{
    public class BuildsViewModel
    {
        public IQueryable<Build> Builds { get; set; }
        public IQueryable<Build> SearchBuilds { get; set;}
        public string SearchBar { get; set; }
        public ILookup<string, Following> Followings { get; set; }
        public string Builder { get; set; }
        public string Build { get; set; }
        public string Category { get; set; }
        public string Case { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Motherboard { get; set; }
        public string PSU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string Price { get; set; }
        public string IsAdminBuild { get; set;}
    }
}