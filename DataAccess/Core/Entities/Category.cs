using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAccess.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Builds = new Collection<Build>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Build> Builds { get; set; }
    }
}
