using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class PSU
    {
        public PSU()
        {
            Builds = new Collection<Build>();
        }
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public ICollection<Build> Builds { get; set; }

        [Display(Name = "PSU Model")]
        public string Model { get; set; }
        public int Watt { get; set; }
        public string Efficiency { get; set; }
        public bool Modularity { get; set; }
        public string Thumbnail { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
