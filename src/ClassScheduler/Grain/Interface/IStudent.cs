using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Data;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface IStudent : IGrainWithGuidKey
    {
        Task SetName(string firstName, string lastName);
        Task<StudentInfo> GetInfo();
        Task<string> GetFullName();
    }
}
