using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface IClassState : IGrainState
    {
        string Name { get; set; }
        string Subject { get; set; }
        Guid Teacher { get; set; }
        IList<IStudent> Students {get; set; } 
    }
}
