using LibrarySystem.Models;
using System;
using System.Linq.Expressions;

namespace LibrarySystem.ViewModels
{
    public class CategoryGridViewModel
    {
        public static Expression<Func<Category, CategoryGridViewModel>> FromCategory
        {
            get
            {
                return cat => new CategoryGridViewModel
                {
                    Id = cat.ID,
                    Name = cat.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}