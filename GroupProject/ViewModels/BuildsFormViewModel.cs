using DataAccess.Core.Entities;
using System.Linq;

namespace GroupProject.ViewModels
{
    public class BuildsFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public int Case { get; set; }
        public IQueryable<Case> Cases { get; set; }
        public int Category { get; set; }
        public IQueryable<Category> Categories { get; set; }
        public int CPU { get; set; }
        public IQueryable<CPU> CPUs { get; set; }
        public int GPU { get; set; }
        public IQueryable<GPU> GPUs { get; set; }
        public int Motherboard { get; set; }
        public IQueryable<Motherboard> Motherboards { get; set; }
        public int PSU { get; set; }
        public IQueryable<PSU> PSUs { get; set; }
        public int RAM { get; set; }
        public IQueryable<RAM> RAMs { get; set; }
        public int Storage { get; set; }
        public IQueryable<Storage> Storages { get; set; }
        public decimal Price { get; set;}
        public bool IsAdminBuild { get; set; }
        public string Header { get; set; }
        public string Action 
        {
            get
            {
                return (Id != 0) ? "Edit" : "Create";
            }
        }
    }
}