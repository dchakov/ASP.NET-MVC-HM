namespace ForumSystem.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.PageableFeedbackList;

    [Authorize]
    public class PageableFeedbackListController : Controller
    {
        const int ItemsPerPage = 4;
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            FeedBackListViewModel viewModel;
            if (this.HttpContext.Cache["Feedback page_" + id] != null)
            {
                viewModel = (FeedBackListViewModel)this.HttpContext.Cache["Feedback page_" + id];
            }
            else
            {
                var page = id;
                var allItemsCount = this.feedbacks.All().Count();
                var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
                var itemsToSkip = (page - 1) * ItemsPerPage;
                var feedbacks = this.feedbacks.All()
                    .OrderBy(x => x.CreatedOn)
                    .ThenBy(x => x.Id)
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .Project().To<FeedbackViewModel>().ToList();

                viewModel = new FeedBackListViewModel()
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    FeedBacks = feedbacks
                };

                this.HttpContext.Cache["Feedback page_" + id] = viewModel;
            }

            return this.View(viewModel);
        }
    }
}