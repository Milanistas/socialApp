using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class Upload
    {
        public int Id { get; set; }
        public string Comm { get; set; }
        public string UpImg { get; set; }
        public string Upvideo { get; set; }
        public DateTime CommDate { get; set; }
        public virtual Register Register { get; set; }
        public virtual Profile Profile { get; set; }
    }
}