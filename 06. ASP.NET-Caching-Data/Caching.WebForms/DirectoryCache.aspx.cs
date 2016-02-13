namespace Caching.WebForms
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web.Caching;

    public partial class DirectoryCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(this.Server.MapPath("~/App_Data"));

            StringBuilder str = new StringBuilder();
            if (files.Length == 0)
            {
                str.Append("<p>");
                str.Append("NO FILES IN FOLDER");
                str.Append("</p>");
            }
            else
            {
                foreach (var item in files)
                {
                    str.Append("<p>");
                    str.Append(item);
                    str.Append("</p>");
                }
            }
            
            if (this.Cache["file"] == null)
            {
                var dependency = new CacheDependency(files);
                var content = string.Format("[{0}]", DateTime.Now);
                Cache.Insert(
                    "file",                    // key
                    content,                   // object
                    dependency,                // dependencies
                    DateTime.Now.AddHours(1),  // absolute exp.
                    TimeSpan.Zero,             // sliding exp.
                    CacheItemPriority.Default, // priority
                    null);                     // callback delegate
            }

            this.filePathSpan.InnerHtml = str.ToString();
            this.currentTimeSpan.InnerText = this.Cache["file"] as string;
        }
    }
}