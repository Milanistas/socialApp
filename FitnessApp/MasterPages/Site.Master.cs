using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.MasterPages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string GetGuid
        {
            get { return Request.QueryString["Guid"]; }
        }

        public string GetId
        {
            get { return Request.QueryString["Id"]; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = HttpContext.Current.User.Identity.Name;

            if (!string.IsNullOrEmpty(user))
            {
                var guid = Request.Cookies.Get(user).Value;
                if (!string.IsNullOrEmpty(guid) && !string.IsNullOrEmpty(GetR))
                {
                    if (guid != GetR.ToLower())
                        form.Visible = false;
                }
                else
                {
                    form.Visible = false;
                }
            }
        }

        public string GetR
        {
            get
            {
                return Request.QueryString["Guid"];
            }
        }
        public IEnumerable<Register> GetFriend()
        {
            var regFriend = new List<Register>();
            using (var p = new DataContext())
            {
                int i;
                int.TryParse(GetId, out i);

                //if (i <= 0) return regFriend;

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
    }
}