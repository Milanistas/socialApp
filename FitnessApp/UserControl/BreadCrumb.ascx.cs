using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessApp.UserControl
{
    public partial class BreadCrumb : System.Web.UI.UserControl
    {
        public int K = 0;
        public int LastJ = 0;
        public string GetR { get { return Request.QueryString["Guid"]; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            var i = new List<KeyValuePair<string, string>>();

            var m = Request.RawUrl.Split('/').ToList();

            m.RemoveAll(x => x == "" || x == " " || x == null);

            var req = Request.QueryString["ReturnUrl"];

            for (int j = 0; j < m.Count(); j++)
            {
                var w = m.Take(j + 1).ToList();
                string Last = w.LastOrDefault();

                if (j > 0)
                {
                    var Contains = Last.Contains(".aspx");
                    if (!Contains)
                        continue;
                }

                var Index = Last.IndexOf('.');
                if (Index != -1)
                    Last = Last.Substring(0, Index);

                if (Last.Equals("Default"))
                    continue;

                Last = Last.Replace("Views", "Home");

                string path = "";
                w.ForEach(x => path += "/" + x);
                if (!string.IsNullOrEmpty(Last))
                    i.Add(new KeyValuePair<string, string>(Last, path));
            }

            LastJ = i.Count;

            rep.DataSource = i;
            rep.DataBind();
        }
    }
}