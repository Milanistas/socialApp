using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FitnessApp.Models
{
    public class Register
    {
        //[Key]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        //public string FirstName { get; set; }
        public string CryptPassWord { get; set; }
        public string ProfileImage { get; set; }
    }
}