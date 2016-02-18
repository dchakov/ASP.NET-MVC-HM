using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    [Authorize]
    public class VotesController : Controller
    {
        IRepository<PostVote> votes;

        public VotesController(IRepository<PostVote> votes)
        {
            this.votes = votes;
        }

        [HttpPost]
        public ActionResult Vote(int postId, int voteType)
        {
            if (voteType > 1)
            {
                voteType = 1;
            }
            if (voteType < -1)
            {
                voteType = -1;
            }

            var userId = this.User.Identity.GetUserId();
            var vote = this.votes.All().FirstOrDefault(x => x.AuthorId == userId && x.PostId == postId);
            if (vote == null)
            {
                vote = new PostVote
                {
                    AuthorId = userId,
                    PostId = postId,
                    Type = (VoteType)voteType
                };
                this.votes.Add(vote);
            }
            else
            {
                if (vote.Type != (VoteType)voteType)
                {
                    vote.Type = VoteType.Neutral;
                }
                else if(vote.Type == VoteType.Neutral)
                {
                    vote.Type = (VoteType)voteType;
                }
            }

            this.votes.SaveChanges();
            var postVotes = this.votes.All()
                .Where(x => x.PostId == postId)
                .Sum(x => (int)x.Type);

            return this.Json(new { Count = postVotes });
        }
    }
}