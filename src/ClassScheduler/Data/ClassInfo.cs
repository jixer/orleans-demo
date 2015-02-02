using System;
using System.Collections.Generic;

namespace Orleans.Samples.ClassScheduler.Data
{
    public class ClassInfo
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public Guid Teacher { get; set; }
        public IList<Guid> Students { get; set; }
    }
}