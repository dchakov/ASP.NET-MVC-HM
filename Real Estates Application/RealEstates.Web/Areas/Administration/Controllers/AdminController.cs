namespace RealEstates.Web.Areas.Administration.Controllers
{
    using Common.Constants;
    using Helpers;
    using System.Web.Mvc;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [ValidateInput(false)]
    public class AdminController : BaseController
    {
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView("_AdminMenu", AdminMenu.Items);
        }
    }
}