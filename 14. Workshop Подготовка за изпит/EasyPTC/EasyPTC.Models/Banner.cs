namespace EasyPTC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Banners")]
    public class Banner : Advertisement
    {
        [Required]
        public string ImageUrl { get; set; }
    }
}
