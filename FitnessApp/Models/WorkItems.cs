using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class WorkItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}