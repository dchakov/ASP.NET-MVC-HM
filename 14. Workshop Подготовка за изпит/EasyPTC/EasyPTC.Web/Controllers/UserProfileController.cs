namespace EasyPTC.Web.Controllers
{
    using EasyPTC.Data;
    using Microsoft.AspNet.Identity;
    using Models;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class UserProfileController : BaseController
    {
        private const string SuccessfulMessageOnVisitBanner = "You successfully updated profile picture!";

        private EasyPtcDbContext data = new EasyPtcDbContext();

        public UserProfileController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateImage(HttpPostedFileBase UploadedImage)
        {
            if (UploadedImage != null)
            {
                var user = this.data.Users.Find(this.User.Identity.GetUserId());

                using (var memory = new MemoryStream())
                {
                    UploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();
                    user.Image = this.CreateImageModel(UploadedImage.FileName, content);
                }
                this.SetSuccessfullMessage(SuccessfulMessageOnVisitBanner);
                this.data.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

        public ActionResult Image()
        {
            var user = this.data.Users.Find(this.User.Identity.GetUserId());

            var image = this.data.Images.Find(user.ImageId);
            if (image == null)
            {
                string path = Path.Combine(this.Server.MapPath("~/Files"), "default.png");
                return this.File(path, "png");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        private Image CreateImageModel(string fileName, byte[] content)
        {
            var image = new Image
            {
                Content = content,
                FileExtension = fileName.Split(new[] { '.' }).Last()
            };

            return image;
        }

        private void SetSuccessfullMessage(string message)
        {
            this.TempData["successfulMessage"] = message;
        }
    }
}
