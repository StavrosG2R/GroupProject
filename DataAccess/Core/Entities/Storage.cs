using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DataAccess.Core.Entities
{
    public class Storage
    {
        public Storage()
        {
            Builds = new Collection<Build>();
        }
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public ICollection<Build> Builds { get; set; }

        [Display(Name = "Storage Model")]
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string StorageType { get; set; }
        public int ReadSpeed { get; set; }
        public int WriteSpeed { get; set; }
        public string Thumbnail { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; } // NotMapped
        public decimal Price { get; set; }
    }
}