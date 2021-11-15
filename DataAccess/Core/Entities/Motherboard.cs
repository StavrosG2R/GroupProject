using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class Motherboard
    {
        public int ID { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int DdrType { get; set; }
        public string Size { get; set; }
        public string Thumbnail { get; set; }
        public int Watt { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
    }
}
