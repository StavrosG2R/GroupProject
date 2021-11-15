using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class PSU
    {
        public int ID { get; set; }
        public int Watt { get; set; }
        public string Efficiency { get; set; }
        public bool Modularity { get; set; }
        public string Thumbnail { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
    }
}
