using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp.Models;

namespace FitnessApp.Views
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<Register> GetReg()
        {
            using (var con = new DataContext())
            {
                return con.Registers.Where(x => x.FirstName.Contains(Getq)).ToList();
            }
        }

        public string Getq { get { return Request.QueryString["q"]; }}
    }
}