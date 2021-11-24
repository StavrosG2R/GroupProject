namespace DataAccess.Core.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public ApplicationUser CommentOwner { get; set; }
        public string CommentOwnerID { get; set; }
        public Build Build { get; set; }
        public int BuildID { get; set; }
    }
}
