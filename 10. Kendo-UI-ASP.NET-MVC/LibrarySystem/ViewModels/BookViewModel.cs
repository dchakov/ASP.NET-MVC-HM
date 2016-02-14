using LibrarySystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace LibrarySystem.ViewModels
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel
                {
                    ID = book.ID,
                    Title = book.Title,
                    Description = book.Description,
                    ISBN = book.ISBN,
                    WebSite = book.WebSite,
                    Author = book.Author,
                    Category = book.Category.Name
                };
            }
        }

        public string Author { get;  set; }

        public string Category { get;  set; }

        public string Description { get;  set; }

        [ScaffoldColumn(false)]
        public int ID { get;  set; }

        public string ISBN { get;  set; }

        public string Title { get;  set; }

        public string WebSite { get;  set; }
    }
}
