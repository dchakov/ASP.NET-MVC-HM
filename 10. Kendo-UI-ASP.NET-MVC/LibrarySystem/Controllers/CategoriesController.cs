using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class CategoriesController : Controller
    {        
        public CategoriesController()
        {
            this.Data = new LibraryDbContext();
        }

        public LibraryDbContext Data { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CategoriesRead([DataSourceRequest]DataSourceRequest request)
        {
            var viewModelCategories = this.Data.Categories.Select(CategoryGridViewModel.FromCategory);

            return Json(viewModelCategories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult CategoriesCreate([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category()
                {
                    Name = category.Name
                };

                newCategory.ID= this.Data.Categories.Add(newCategory).ID;
                this.Data.SaveChanges();
                category.Id = newCategory.ID;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CategoriesUpdate([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    ID = category.Id,
                    Name = category.Name
                };
                this.Data.Categories.Attach(newCategory);
                this.Data.Entry(newCategory).State = EntityState.Modified;
                this.Data.SaveChanges();

            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CategoriesDelete([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var toDelete = new Category()
                {
                    ID = category.Id,
                    Name = category.Name
                };

                this.Data.Categories.Attach(toDelete);
                this.Data.Categories.Remove(toDelete);
                this.Data.SaveChanges();
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
    }
}

