using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Entities
{
    public class SuggestedBuild
    {
        public int ID { get; set; }
        public string Name { get; set; }
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
    }
}
