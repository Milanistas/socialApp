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
                var reg = w.Registers.Where(x => x.FirstName.ToString() == User.Identity.Name);
                ProfileImg.ImageUrl =  reg.FirstOrDefault().ProfileImage ?? "";
                w.Dispose();
            }

            textarea.Attributes.Add("maxlength", "150");
        }

        public string GetPic
        {
            get { return Path.Combine("/Static/Profile", fi.FileName); }
        }

        public void Comm_Click(object sender, EventArgs e)
        {

            textarea.Text = textarea.Text.Replace("\r\n", "<br />");
            textarea.Text = textarea.Text.Replace("                                                                                                                                          ", "<br />");

            using (var data = new DataContext())
            {
                var profi = new Models.Profile
                {
                    Register = data.Registers.FirstOrDefault(x => x.FirstName == User.Identity.Name)
                };

                var upPath = "";

                if (fi.HasFile)
                {
                    upPath = GetPic;
                    var mapped = Server.MapPath(upPath);
                    fi.SaveAs(mapped);
                }

                var up = new Models.Upload
                {
                    Comm = textarea.Text,
                    CommDate = DateTime.Now,
                    UpImg = fi.HasFile ? GetPic : "",
                    Profile = profi,
                    Register = profi.Register
                };

                data.Uploads.AddOrUpdate(up);

                data.SaveChanges();
            }

            GetProfile();

            textarea.Text = "";
        }

        public void GetProfile()
        {
            var w = new DataContext();
            var up = w.Uploads.Where(x => x.Register.FirstName.Equals(User.Identity.Name)).ToArray();
            rep.DataSource = up.OrderByDescending(x=>x.Id).ToArray();
            rep.DataBind();
            w.Dispose();
        }

        public IEnumerable<Models.Upload> GetImgUploads()
        {
            using (var context = new DataContext())
            {
                return context.Uploads.Where(x => !string.IsNullOrEmpty(x.UpImg) && x.Register.FirstName.Equals(User.Identity.Name)).ToList();
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