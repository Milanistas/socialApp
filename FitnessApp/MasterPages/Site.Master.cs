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
using FitnessApp.Models;

namespace FitnessApp.MasterPages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string GetId
        {
            get { return Request.QueryString["Id"]; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchText.Attributes.Add("placeholder", "Enter profile name");
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                LogOut.Visible = false;
                SearchText.Visible = false;
                Search.Visible = false;
            }
        }

        public IEnumerable<Register> GetFriend()
        {
            var regFriend = new List<Register>();
            using (var p = new DataContext())
            {
                int i;
                int.TryParse(GetId, out i);

                var pro = p.Profiles.Where(x => x.Register.Id == i);
                var FriendId = pro.Select(x => x.FriendId).Where(x => x > 0).ToList();
                FriendId.ForEach(o => regFriend.Add(p.Registers.FirstOrDefault(x => x.Id == o)));
            }
            return regFriend.Where(x => !string.IsNullOrEmpty(x.Guid.ToString())).Distinct();
        }

        public static List<KeyValuePair<string, string>> GetListItems()
        {
            return new List<KeyValuePair<string, string>> 
            {   
                new KeyValuePair<string, string>("http://localhost:42596/Views/", "Hem"),
                new KeyValuePair<string, string>("http://localhost:42596/Views/", "Contact"),
                new KeyValuePair<string, string>("http://localhost:42596/Views/", "About"),
                new KeyValuePair<string, string>("http://localhost:42596/Views/Register.aspx/", "Register"),
                new KeyValuePair<string, string>("http://localhost:42596/Views/Login.aspx/ ", "Login")
            };
        }

        public IEnumerable<Models.Register> GetRegisters()
        {
            using (var con = new DataContext())
            {
                return con.Registers.Where(x => x.FirstName != HttpContext.Current.User.Identity.Name).ToList();
            }
        }

        protected void LogOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Search.aspx" + "?q=" + SearchText.Text);
        }
    }
}