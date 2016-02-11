namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Twitter.Data;
    using Twitter.Models;
    using Twitter.Web.Models;

    public class HomeController : BaseController
    {
        public HomeController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            IEnumerable<UserViewModel> users = this.Data.Users.All()
                .AsQueryable()
                .Select(user => new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.UserName
                });
            IEnumerable<TagViewModel> tags = this.Data.Tags.All()
                .AsQueryable()
                .Select(u => new TagViewModel()
                {
                    Name = u.Name
                });

            HomePageViewModel vm = new HomePageViewModel()
            {
                Tags = tags,
                Users = users
            };
            return View(vm);
        }

        public ActionResult UserPage(string Id)
        {
            var appUser = this.Data.Users.GetById(Id);

            UserPageViewModel vm = new UserPageViewModel()
            {
                Username = appUser.UserName,
                Tweets = appUser.Tweets.OrderByDescending(x => x.CreatedOn).ToList(),
                Tweet = new Tweet()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult UserPage(string Id, [Bind(Exclude = "Id")] Tweet postedTweet)
        {
            var appUser = this.Data.Users.GetById(Id);
            if (ModelState.IsValid)
            {

                postedTweet.UserId = User.Identity.GetUserId();
                postedTweet.CreatedOn = DateTime.Now;
                appUser.Tweets.Add(postedTweet);
                this.Data.SaveChanges();

                var words = postedTweet.Message.Split();
                postedTweet.Tags = new HashSet<Tag>();
                foreach (var word in words)
                {
                    if (word[0] == '#')
                    {
                        var newTag = new Tag()
                        {
                            Name = word
                        };
                        var tag = this.Data.Tags.All().FirstOrDefault(x => x.Name == word);
                        if (tag != null)
                        {
                            postedTweet.Tags.Add(tag);
                        }
                        else
                        {
                            postedTweet.Tags.Add(newTag);
                        }
                    }
                }

                this.Data.SaveChanges();
            }

            UserPageViewModel vm = new UserPageViewModel()
            {
                Username = appUser.UserName,
                Tweets = appUser.Tweets.OrderByDescending(x => x.CreatedOn).ToList(),
                Tweet = new Tweet()
            };

            return View(vm);
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            var currentUserId = User.Identity.GetUserId();

            if (currentUserId != null)
            {
                return RedirectToAction("UserPage", new { id = currentUserId });
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [OutputCacheAttribute(VaryByParam = "name", Duration = 15 * 60)]
        public ActionResult TweetsByTag(string name)
        {
            var tag = this.Data.Tags.All().FirstOrDefault(x => x.Name == name);
            var tweets = tag.Tweets
                .Select(u => new TweetViewModel()
                {
                    User = u.User.UserName,
                    CreatedOn = u.CreatedOn,
                    Message = u.Message

                });

            return View(tweets);
        }
    }
}