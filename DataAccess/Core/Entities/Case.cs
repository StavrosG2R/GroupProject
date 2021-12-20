using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class Case
    {
        public Case()
        {
            Builds = new Collection<Build>();
            SuggestedBuilds = new Collection<SuggestedBuild>();
        }
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<SuggestedBuild> SuggestedBuilds { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public int NumberOfFans { get; set; }
        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}
