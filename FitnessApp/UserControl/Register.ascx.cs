using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.UserControl
{
    public partial class Register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fName.Text) && !string.IsNullOrEmpty(pass.Text))
            {
                var reg = new Models.Register
                {
                    FirstName = fName.Text,
                    CryptPassWord = pass.Text,
                    Guid = Guid.NewGuid(),
                    ProfileImage = PicPath
                };

                using (var data = new DataContext())
                {
                    data.Registers.Add(reg);
                    data.SaveChanges();
                }
                FormsAuthentication.SetAuthCookie(fName.Text, true);
                Response.Redirect("~/Views/Default.aspx");
            }
            else
            {
                text.Text = "Enter a valid reg!";
            }
        }
        private static string PicPath { get { return Path.Combine("/Static/Profile", "profile.png"); } }
    }
}