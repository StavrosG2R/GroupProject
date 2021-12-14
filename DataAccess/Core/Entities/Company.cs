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
        public ICollection<Case> Cases { get; private set; }
        public ICollection<CPU> CPUs { get; private set; }
        public ICollection<Game> Games { get; private set; }
        public ICollection<GPU> GPUs { get; private set; }
        public ICollection<Motherboard> Motherboards { get; private set; }
        public ICollection<PSU> PSUs { get; private set; }
        public ICollection<RAM> RAMs { get; private set; }
        public ICollection<Storage> Storages { get; private set; }
    }
}
