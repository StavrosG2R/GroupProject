using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Entities
{
    public class Build
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ApplicationUser Builder { get; set; }
        public string BuilderID { get; set; }
        public Case Case { get; set; }
        public CPU CPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM RAM { get; set; }
        public GPU GPU { get; set; }
        public PSU PSU { get; set; }
        public Storage Storage { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}
