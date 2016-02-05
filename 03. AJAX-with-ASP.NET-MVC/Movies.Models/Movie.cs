namespace Movies.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Studio { get; set; }

        public string StudioAddress { get; set; }

        public int Year { get; set; }

        public int LeadMaleActorId { get; set; }

        [ForeignKey("LeadMaleActorId")]
        public virtual Actor LeadMaleActor { get; set; }

        public int LeadFemaleActorId { get; set; }

        [ForeignKey("LeadFemaleActorId")]
        public virtual Actor LeadFemaleActor { get; set; }
    }
}
