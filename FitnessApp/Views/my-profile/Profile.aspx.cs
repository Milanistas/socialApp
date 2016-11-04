using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.Views.my_profile
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProfile();

                var w = new DataContext();
                var reg = w.Registers.Where(x => x.Guid.ToString() == GetR);
                ProfileImg.ImageUrl = reg.Any()
                    ? reg.FirstOrDefault().ProfileImage
                    : Path.Combine("/Static/Profile", "profile.png");
                w.Dispose();
            }

            textarea.Attributes.Add("maxlength", "150");
        }

        public void Comm_Click(object sender, EventArgs e)
        {
            //\n
            //<br />



            textarea.Text = textarea.Text.Replace("\r\n", "<br />");
            textarea.Text = textarea.Text.Replace("                                                                                                                                          ", "<br />");

            var w = new DataContext();

            var profi = new Models.Profile
            {
                Register = w.Registers.FirstOrDefault(x => x.Guid.ToString() == GetR)
            };

            var upPath = "";

            if (fi.HasFile)
            {
                upPath = Path.Combine("/Static/Profile", fi.FileName);
                var mapped = Server.MapPath(upPath);
                fi.SaveAs(mapped);
            }

            var up = new Models.Upload
            {
                Comm = textarea.Text,
                CommDate = DateTime.Now,
                UpImg = upPath,
                Profile = profi,
                Register = profi.Register
            };
            w.Uploads.AddOrUpdate(up);

            //w.Profiles.AddOrUpdate(profi);

            w.SaveChanges();
            w.Dispose();

            GetProfile();

            textarea.Text = "";
        }

        public void GetProfile()
        {
            if (!string.IsNullOrEmpty(GetR))
            {
                var w = new DataContext();
                //var prof = w.Profiles.Where(x => x.Register.Guid.ToString() == GetR).ToArray();
                var up = w.Uploads.Where(x => x.Register.Guid.ToString() == GetR).ToArray();
                //var pro = up.Select(x => x.Register);
                rep.DataSource = up.Reverse().ToArray();
                rep.DataBind();
                w.Dispose();
            }
        }

        public IEnumerable<Models.Upload> GetImgUploads()
        {
            using (var context = new DataContext())
            {
                return context.Uploads.Where(x => !string.IsNullOrEmpty(x.UpImg) && x.Register.Guid.ToString() == GetR).ToList();
            }
        }

        public string GetR
        {
            get
            {
                return Request.QueryString["Guid"];
            }
        }

        protected void Remove(object sender, EventArgs e)
        {
            Button someButton = sender as Button;
            if (someButton == null)
                return;

            int i;
            int.TryParse(someButton.CommandArgument, out i);

            var DataContext = new DataContext();
            var o = DataContext.Uploads.FirstOrDefault(x => x.Id == i);

            if (o == null)
            {
                DataContext.Dispose();
                return;
            }

            DataContext.Uploads.Remove(o);

            DataContext.SaveChanges();
            DataContext.Dispose();
            GetProfile();
        }
    }
}