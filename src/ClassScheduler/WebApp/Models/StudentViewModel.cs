using System;
using System.Collections;
using System.Collections.Generic;

namespace Orleans.Samples.ClassScheduler.WebApp.Models
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string> Classes { get; set; }
    }
}