using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string TextMessage { get; set; }
        public DateTime Date { get; set; }
        public virtual Register Register { get; set; }
    }
}