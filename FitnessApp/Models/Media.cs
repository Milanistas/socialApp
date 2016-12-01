using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string UpImg { get; set; }
        public string Upvideo { get; set; }
        public virtual Upload Upload { get; set; }
    }
}