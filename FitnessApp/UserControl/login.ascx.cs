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
            //if ((UserEmail.Text == "mm") &&
            //        (UserPass.Text == "123"))
            //{ 
            using (var m = new DataContext())
            {
                var o = m.Registers.Where(x => x.FirstName == UserEmail.Text && x.CryptPassWord == UserPass.Text);
                if (o.Any())
                {
                    Response.Cookies.Add(new HttpCookie(o.First().FirstName, o.First().Guid.ToString()));

                    FormsAuthentication.SetAuthCookie(UserEmail.Text, Persist.Checked);
                    var q = Request.QueryString["ReturnUrl"];
                    if (q.Equals("/"))
                        q = q.Replace("/", "/Views");
                    var Encode = HttpUtility.HtmlEncode(q);

                    //using (var m = new DataContext())
                    //{
                    //    var o = m.Registers.Where(x => x.FirstName == UserEmail.Text);
                    //    if (o.Any())
                    //    {
                    //        //var p = o.First().Guid.ToString();
                    //        //var ä = p.ToList().RemoveAll(c=> c == '-');
                    //        //var arr = Convert.FromBase64String(p);
                    //        //var cookie = new HttpCookie("myGuid",
                    //        //Convert.ToBase64String(ProtectedData.Protect(arr, null,
                    //        //    DataProtectionScope.CurrentUser))) {Expires = DateTime.Now.AddDays(7)};
                    //        //Response.Cookies.Add(p);
                    //    }
                    //}

                    Response.Redirect(Encode);
                }
                else
                {
                    Msg.Text = "Invalid credentials. Please try again.";
                }
            }
            //}
            
        }
    }
}