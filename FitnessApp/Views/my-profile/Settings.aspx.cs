using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessApp.Views
{
    public partial class Settings : System.Web.UI.Page
    {
        public string GetId
        {
            get { return Request.QueryString["Id"]; }
        }
        public string GetR { get { return Request.QueryString["Guid"]; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            p.Visible = true;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(GetR))
                {
                    var w = new DataContext();

                    var profi = w.Registers.FirstOrDefault(x => x.Guid.ToString() == GetR);

                    if (profi != null)
                    {
                        ProfileImg.ImageUrl = profi.ProfileImage ?? PicPath;
                        firstName.Text = profi.FirstName ?? "";
                    }
                    w.Dispose();
                }
            }

            if (string.IsNullOrEmpty(ProfileImg.ImageUrl))
                ProfileImg.ImageUrl = PicPath;

            ProfileImg2.Visible = ProfileImg.ImageUrl != PicPath;
        }

        public void ProfileImg_Click(object sender, EventArgs e)
        {
            if (ImgUp.HasFile)
            {
                var upPath = Path.Combine("/Static/Profile", ImgUp.FileName);
                var mapped = Server.MapPath(upPath);
                ImgUp.SaveAs(mapped);
                ProfileImg.ImageUrl = upPath;
                ProfileImg2.Visible = true;
            }

            using (var w = new DataContext())
            {
                //w.Register.Add(w.Profile.Where(x=>x.Register.))

                var reg = new Models.Register
                {
                    FirstName = "mm",
                    CryptPassWord = "123",
                    Guid = Guid.NewGuid(),
                    ProfileImage = ProfileImg.ImageUrl
                };

                var pro = new Profile
                {
                    Register = reg
                };

                w.Profiles.AddOrUpdate(pro);
                w.SaveChanges();

                var k = w.Registers.FirstOrDefault(x => x.Guid.ToString() == GetR);
                if (k != null)
                {
                    k.ProfileImage = ProfileImg.ImageUrl;
                    w.Registers.AddOrUpdate(k);
                }
            }
        }
        public void ProfileImg1_Click(object sender, EventArgs e)
        {
            ProfileImg.ImageUrl = PicPath;
            ProfileImg2.Visible = false;
        }

        private static string PicPath { get { return Path.Combine("/Static/Profile", "profile.png"); } }
    }
}