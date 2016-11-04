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
            var req = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(req))
            {
                int i;
                var p = new DataContext();
                int.TryParse(req, out i);
                var First = p.Uploads.FirstOrDefault(x => x.Id == i);
                if (First != null)
                {
                    Response.Write(First.Comm);
                }
                p.Dispose();
            }
        }
    }
}