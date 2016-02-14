namespace LibrarySystem.ViewModels
{
    using LibrarySystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return cat => new CategoryViewModel
                {
                    Id = cat.ID,
                    Name = cat.Name,
                    Books = cat.Books
                };
            }
        }

        public ICollection<Book> Books { get; private set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}