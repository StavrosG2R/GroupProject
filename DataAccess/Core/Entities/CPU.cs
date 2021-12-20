using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class CPU
    {
        public CPU()
        {
            Builds = new Collection<Build>();
            SuggestedBuilds = new Collection<SuggestedBuild>();
        }
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<SuggestedBuild> SuggestedBuilds { get; set; }
        public string Socket { get; set; }
        public string Model { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double Frequency { get; set; }
        public int Watt { get; set; }
        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
