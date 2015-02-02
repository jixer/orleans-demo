using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orleans.Samples.ClassScheduler.WebApp.Models
{
    public class ClassViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public int ClassSize { get; set; }
    }
}