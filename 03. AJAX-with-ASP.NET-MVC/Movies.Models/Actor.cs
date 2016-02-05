namespace Movies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
