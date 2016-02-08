namespace Twitter.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    [Authorize(Roles = "Administrator")]
    [ValidateInput(false)]
    public class AdminController : Controller
    {
        [ChildActionOnly]
        public ActionResult Menu()
        {
            IEnumerable<string> Items = new List<string>() { "Tweets", "Tags" };
            return this.PartialView("_AdminMenu", Items);
        }
    }
}