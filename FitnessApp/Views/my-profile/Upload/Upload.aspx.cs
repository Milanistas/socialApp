using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.Views.my_profile.Upload
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Models.Upload> GetUpload()
        {
            int reqId;
            int.TryParse(Request.QueryString["id"], out reqId);
            using (var context = new DataContext())
            {
                return context.Uploads.Where(x => x.Id == reqId).ToList();
            }
        }

        public IEnumerable<Models.Comment> GetComment()
        {
            int reqId;
            int.TryParse(Request.QueryString["id"], out reqId);
            using (var context = new DataContext())
            {
                return context.Comments.Where(x => x.Upload.Id == reqId).ToList();
            }
        }

        public void SaveComment(object o, EventArgs e)
        {
            int reqId;
            int.TryParse(Request.QueryString["id"], out reqId);
            using (var context = new DataContext())
            {
                var upload = context.Uploads.FirstOrDefault(x => x.Id == reqId);
                context.Comments.Add(new Comment {PostedComment = comm.Text, Upload = upload});
                context.SaveChanges();
            }
        }
    }
}