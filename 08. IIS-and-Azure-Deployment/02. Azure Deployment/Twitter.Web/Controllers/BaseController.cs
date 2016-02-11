namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Twitter.Data;

    public class BaseController : Controller
    {
        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        public IUowData Data { get; set; }
    }
}