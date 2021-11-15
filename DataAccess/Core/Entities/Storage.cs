using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class Storage
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public int ReadSpeed { get; set; }
        public int WriteSpeed { get; set; }
        public string Thumbnail { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
