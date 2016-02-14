using Kendo.Mvc.UI;
using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            this.Data = new LibraryDbContext();
        }

        public LibraryDbContext Data { get; private set; }

        public ActionResult Index()
        {
            var result = this.Data.Categories.Include("Books").ToList()
                .Select(x => new TreeViewItemModel
                {
                    Text = x.Name,
                    Items = x.Books.Select(y => new TreeViewItemModel
                    {
                        Text = y.Title
                    })
                        .ToList()
                });

            ViewModels.IndexViewModel homeVm = new ViewModels.IndexViewModel()
            {
                TreeViewItems = result,
                Books = Data.Books.Select(BookViewModel.FromBook)
            };

            return View(homeVm);
        }

        public ActionResult BookDetails(string serversideautocomplete)
        {
            if (serversideautocomplete != null)
            {
                var found = Data.Books.FirstOrDefault(x => x.Title == serversideautocomplete);
                if (found != null)
                {
                    return View("BookDetails", found);
                }
            }

            return Redirect("Index");
        }

        public JsonResult GetAutocompleteData(string text)
        {
            var selectedBooks = this.Data.Books
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .Select(BookViewModel.FromBook);

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }
    }
}