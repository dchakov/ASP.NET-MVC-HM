namespace Twitter.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TweetViewModel
    {
        [Required]
        [StringLength(140, MinimumLength = 5, ErrorMessage = "Message length must be between 5 and 140 symbols")]
        public string Message { get; set; }

        [Required]
        public string User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}