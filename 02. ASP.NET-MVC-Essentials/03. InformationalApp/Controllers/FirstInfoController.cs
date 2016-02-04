using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.InformationalApp.Controllers
{
    public class FirstInfoController : Controller
    {
        // GET: FirstInfo
        public ActionResult Index()
        {
            return View();
        }
    }
}