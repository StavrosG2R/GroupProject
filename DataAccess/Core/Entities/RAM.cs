using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class RAM
    {
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public string Model { get; set; }
        public int Frequency { get; set; }
        public int DdrType { get; set; }
        public int Storage { get; set; }
        public string Thumbnail { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
