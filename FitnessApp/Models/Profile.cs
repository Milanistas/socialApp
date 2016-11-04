using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI.WebControls;

namespace FitnessApp.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public bool IsAuth
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public int FriendId { get; set; }
        public virtual Register Register { get; set; }
    }
}