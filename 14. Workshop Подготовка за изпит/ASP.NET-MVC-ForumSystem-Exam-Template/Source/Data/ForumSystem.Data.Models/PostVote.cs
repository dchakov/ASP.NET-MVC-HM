namespace ForumSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostVote
    {
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public VoteType Type { get; set; }
    }
}
