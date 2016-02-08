using Microsoft.AspNet.Identity;
using Ninject;
using RealEstates.Data.Repositories;
using RealEstates.Model;
using RealEstates.Services.Contracts;
using RealEstates.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Web.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult Index()
        {
            return View();
        }

        

    }
}