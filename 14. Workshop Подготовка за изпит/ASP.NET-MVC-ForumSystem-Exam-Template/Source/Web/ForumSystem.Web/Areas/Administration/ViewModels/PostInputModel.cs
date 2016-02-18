using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Administration.ViewModels
{
    public class PostInputModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
               
        [AllowHtml]
        public string Content { get; set; }
    }
}