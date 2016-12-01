using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.Views
{
    public partial class UserPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var con = new DataContext())
            {
                rep.DataSource = GetUploads(con).Reverse();
                rep.DataBind();
            }
        }

        public IEnumerable<Models.Upload> GetUploads(DataContext con)
        {
            if (!string.IsNullOrEmpty(GetPId))
                return con.Uploads.Where(x => x.Register.FirstName == GetPId).ToList();
            return con.Uploads.ToList();
        }

        public string GetPId { get { return Request.QueryString["pId"]; } }
    }
}