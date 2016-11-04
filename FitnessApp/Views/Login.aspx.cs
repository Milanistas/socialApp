using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            using (var context = new DataContext())
            {
                var passWord = pass.Text.GetHashCode().ToString();
                //var user = context.Registers.FirstOrDefault(c=> c.FirstName == fName.Text);
                //if (user != null)
                //{
                //    Response.Write("Inloggad");
                //}
                //else
                //{
                //    Response.Write("Försök igen");
                //}
            }
        }
    }
}