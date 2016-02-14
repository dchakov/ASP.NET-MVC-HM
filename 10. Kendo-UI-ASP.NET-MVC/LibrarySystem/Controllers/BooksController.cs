using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        public BooksController()
        {
            this.Data = new LibraryDbContext();
        }

        public LibraryDbContext Data { get; set; }

        public ActionResult Index()
        {
            this.PopulateDropDowns();

            return View();
        }

        private void PopulateDropDowns()
        {
            var categories = this.Data.Categories
                 .Select(CategoryGridViewModel.FromCategory).OrderBy(s => s.Name);

            this.ViewData["categories"] = categories;
            this.ViewData["defaultCategory"] = categories.First();
        }

        public JsonResult ReadBooks([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data.Books.Include("Categories").Select(BookViewModel.FromBook);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateBook([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                int bookId = int.Parse(book.Category);
                var category = this.Data.Categories.FirstOrDefault(x => x.ID == bookId);

                var newBook = new Book
                {
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category = category,
                    ISBN = book.ISBN,
                    WebSite = book.WebSite
                };

                this.Data.Books.Add(newBook);
                this.Data.SaveChanges();

                book.ID = newBook.ID;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBook([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            var existingBook = this.Data.Books.FirstOrDefault(x => x.ID == book.ID);

            if (book != null && ModelState.IsValid)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.WebSite = book.WebSite;

                int bookId = int.Parse(book.Category);
                existingBook.Category = this.Data.Categories.FirstOrDefault(x => x.ID == bookId);

                this.Data.SaveChanges();
            }

            return Json((new[] { book }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBook([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            var existingBook = this.Data.Books.FirstOrDefault(x => x.ID == book.ID);

            this.Data.Books.Remove(existingBook);
            this.Data.SaveChanges();

            return Json(new[] { book }, JsonRequestBehavior.AllowGet);
        }
    }
}
