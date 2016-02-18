namespace ForumSystem.Data.Models
{
    using Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Feedback : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
