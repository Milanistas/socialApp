using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FitnessApp.Views.message
{
    public partial class message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["myId"]) && !string.IsNullOrEmpty(Request.QueryString["uId"]))
            {

            }
        }

        public void GetMessages()
        {

        } 

        protected void Post(object sender, EventArgs e)
        {

        }
    }
}