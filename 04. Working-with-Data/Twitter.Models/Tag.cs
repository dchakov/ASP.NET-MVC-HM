namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        private ICollection<Tweet> tweets;

        public Tag()
        {
            this.tweets = new HashSet<Tweet>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Tag name must be between 1 and 50 symbols")]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }
    }
}
