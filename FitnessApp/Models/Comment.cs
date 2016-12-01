using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string PostedComment { get; set; }
        public virtual Upload Upload { get; set; }
    }
}