using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Entities
{
    public class Following
    {
        public string FollowerId { get; set; }
        public string FolloweeId { get; set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }
    }
}
