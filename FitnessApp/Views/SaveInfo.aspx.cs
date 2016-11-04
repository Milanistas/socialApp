using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.Views
{
    public partial class SaveInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var values = Request.QueryString.Get("Values");

            using (var context = new DataContext())
            {
                //context.WorkItems.Add(new WorkItems { Name = values});
            }
        }
    }
}