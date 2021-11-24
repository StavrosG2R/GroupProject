using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class Motherboard
    {
        public Motherboard()
        {
            Builds = new Collection<Build>();
        }
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public ICollection<Build> Builds { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public string Model { get; set; }
        public int DdrType { get; set; }
        public string Size { get; set; }
        public int Watt { get; set; }
        public string Thumbnail { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
