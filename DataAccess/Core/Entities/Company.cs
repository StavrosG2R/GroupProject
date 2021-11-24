using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAccess.Core.Entities
{
    public class Company
    {
        //! New added
        public Company()
        {
            Cases = new Collection<Case>();
            CPUs = new Collection<CPU>();
            Games = new Collection<Game>();
            GPUs = new Collection<GPU>();
            Motherboards = new Collection<Motherboard>();
            PSUs = new Collection<PSU>();
            RAMs = new Collection<RAM>();
            Storages = new Collection<Storage>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        //! new added
        public ICollection<Case> Cases { get; set; }
        public ICollection<CPU> CPUs { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<GPU> GPUs { get; set; }
        public ICollection<Motherboard> Motherboards { get; set; }
        public ICollection<PSU> PSUs { get; set; }
        public ICollection<RAM> RAMs { get; set; }
        public ICollection<Storage> Storages { get; set; }
    }
}
