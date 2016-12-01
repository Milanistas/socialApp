using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.UserControl
{
    public partial class login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Logon_Click(object sender, EventArgs e)
        {
            using (var m = new DataContext())
            {
                var o = m.Registers.Where(x => x.FirstName == UserEmail.Text && x.CryptPassWord == UserPass.Text);
                if (o.Any())
                {
                    FormsAuthentication.SetAuthCookie(UserEmail.Text, Persist.Checked);

                    Response.Redirect("~/Views/Default.aspx");
                }
                else
                {
                    Msg.Text = "Login again!";
                }
            }
        }
    }
}