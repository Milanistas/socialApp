using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Util;

namespace FitnessApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=twitter")
        {
        }

        public DbSet<Register> Registers { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Upload> Uploads { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Media> Media { get; set; }
        //public DbSet<WorkItems> WorkItems { get; set; } 
    }
}