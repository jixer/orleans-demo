using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Data;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface ITeacher : IGrainWithGuidKey
    {
        Task SetName(string firstName, string lastName);
        Task<TeacherInfo> GetInfo();
        Task<string> GetFullName();
    }
}
