using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace FitnessApp.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected bool MonthBegun = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //file.Visible = false;
            //if (User.Identity.IsAuthenticated)
            //{
            //    file.Visible = true;
            //}
            //file.AllowMultiple = true;
        }
        public string GetR
        {
            get
            {
                return Request.QueryString["Guid"];
            }
        }
        //public IEnumerable<string> GetImage()
        //{
            //var img = new List<KeyValuePair<int, string>>();
            //var img = new List<System.Web.UI.WebControls.Image>();

            //if (IsPostBack)
            //{
            //    if (file.HasFiles)
            //    {
            //            var path = Path.Combine("/Static/Img/", file.PostedFile.FileName);
            //            var mapped = Server.MapPath(path);
            //            file.SaveAs(mapped);
            //            yield return path;

            //        //foreach (var item in file.PostedFiles)
            //        //{
            //                                    //img.Add(new System.Web.UI.WebControls.Image { ImageUrl = path });
            //            //img.Add(new KeyValuePair<int, string>(m, path));
            //            //yield return new System.Web.UI.WebControls.Image {ImageUrl = path};
            //        //}
            //    }
            //}
        //}

        public IEnumerable<string> GetCalendarMonths()
        {
            for (var i = 1; i <= 12; i++)
            {
                MonthBegun = true;
                for (var k = 1; k <= DateTime.DaysInMonth(DateTime.UtcNow.Year, i); k++)
                {
                    var dayOfWeek = new DateTime(DateTime.UtcNow.Year, i, k).ToString("dddd", CultureInfo.CurrentCulture);
                    yield return k + ". " + dayOfWeek;
                    MonthBegun = false;
                }
            }
        }

        public object GetMonthName(int number)
        {
            return new DateTime(DateTime.UtcNow.Year, number, 1).ToString("MMMM", CultureInfo.CurrentCulture);
        }
    }


    enum Months
    {
        Januari = 1,
        Februari = 2,
        Mars = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        Oktober = 10,
        November = 11,
        December = 12
    }
}