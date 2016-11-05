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
            //FormsAuthentication.SignOut();
            //Request.Cookies.Remove(".ASPXFORMSAUTH");
            //Response.Write(Context.User.Identity.IsAuthenticated);
            //Response.Write(Context.User.Identity.Name);
        }

        public void Logon_Click(object sender, EventArgs e)
        {
            using (var m = new DataContext())
            {
                var o = m.Registers.Where(x => x.FirstName == UserEmail.Text && x.CryptPassWord == UserPass.Text);
                if (o.Any())
                {
                    Response.Cookies.Add(new HttpCookie(o.First().FirstName, o.First().Guid.ToString()));

                    var builder = new UriBuilder(Request.Url);
                    var query = HttpUtility.ParseQueryString(builder.Query);
                    query["guid"] = o.First().Guid.ToString();
                    query.Remove("ReturnUrl");
                    builder.Query = query.ToString();
                    string url = builder.ToString();

                    FormsAuthentication.SetAuthCookie(UserEmail.Text, Persist.Checked);

                    Response.Redirect(url);
                }
            }
        }
    }
}