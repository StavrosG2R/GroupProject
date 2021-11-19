using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public ApplicationUser CommentOwner { get; set; }
        public string CommentOwnerId { get; set; }
        public Build Build { get; set; }
        public int BuildId { get; set; }
    }
}
