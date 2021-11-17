using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class GPU
    {
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public string Chipset { get; set; }
        public string Model { get; set; }
        public int Watt { get; set; }
        public int Vram { get; set; }
        public string Thumbnail { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
