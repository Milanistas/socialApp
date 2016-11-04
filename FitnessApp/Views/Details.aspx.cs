using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessApp.Views
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var idQuery = Request.QueryString.Get("Id");
            var day = Request.QueryString.Get("day");
            var month = Request.QueryString.Get("month");
            var numberDay = Request.QueryString.Get("nday");

            dateLabel.Text = string.Format("{0} den {1} {2} {3}", day, numberDay, month, DateTime.Now.Year);
            //return (event.keyCode!=13);
            //itemText.Attributes.Add("onkeypress", "return false;");
            //itemText.Attributes.Add("onkeydown", "");
        }
    }
}