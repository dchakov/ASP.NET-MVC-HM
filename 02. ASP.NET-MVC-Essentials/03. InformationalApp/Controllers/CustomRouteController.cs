using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.InformationalApp.Controllers
{
    public class CustomRouteController : Controller
    {
        // GET: User
        public string ByUsername(string username)
        {
            return string.Format("Username is: {0}", username);
        }
    }
}