using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public string Name { get; set; }
    }
}
