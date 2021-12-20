using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Entities
{
    public class Build
    {
        public Build()
        {
            Comments= new Collection<Comment>();
        }
        public int ID { get; set; }

        [Display(Name = "Build Name")]
        public string Name { get; set; }
        public ApplicationUser Builder { get; set; }
        public string BuilderID { get; set; }
        public Case Case { get; set; }
        public int CaseID { get; set; }
        public CPU CPU { get; set; }
        public int CPUID { get; set; }
        public Motherboard Motherboard { get; set; }
        public int MotherboardID { get; set; }
        public RAM RAM { get; set; }
        public int RAMID { get; set; }
        public GPU GPU { get; set; }
        public int GPUID { get; set; }
        public PSU PSU { get; set; }
        public int PSUID { get; set; }
        public Storage Storage { get; set; }
        public int StorageID { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public ICollection<Comment> Comments { get; set; }

        [NotMapped]
        [Display(Name = "Builder Name")]
        public string BuilderName { get; set; }
    }
}
