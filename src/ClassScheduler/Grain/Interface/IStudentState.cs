using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface IStudentState : IGrainState
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        IList<ICollegeClass> CLasses { get; set; }
    }
}
