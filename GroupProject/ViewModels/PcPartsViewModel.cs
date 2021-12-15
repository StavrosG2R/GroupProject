using DataAccess.Core.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace GroupProject.ViewModels
{
    public class PcPartsViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public Case Case { get; set; }
        public CPU CPU { get; set; }
        public GPU GPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public PSU PSU { get; set; }
        public RAM RAM { get; set; }
        public Storage Storage { get; set; }
    }
}