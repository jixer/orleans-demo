using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface ITeacherState : IGrainState
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
