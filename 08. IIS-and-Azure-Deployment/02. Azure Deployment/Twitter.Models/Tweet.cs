namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<Tag> tags;

        public Tweet()
        {
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(140, MinimumLength = 5, ErrorMessage = "Message length must be between 5 and 140 symbols")]
        public string Message { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
