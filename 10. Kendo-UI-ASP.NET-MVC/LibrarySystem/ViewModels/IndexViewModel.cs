namespace LibrarySystem.ViewModels
{
    using Kendo.Mvc.UI;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<TreeViewItemModel> TreeViewItems { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}