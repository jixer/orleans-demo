using System;
using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Data;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface ICollegeClass : IGrainWithGuidKey
    {
        Task Configure(string name, string subject);
        Task AssignTeacher(Guid teacherId);
        Task RegisterStudent(Guid studentId);
        Task<string> GetName();
        Task<string> GetSubject();
        Task<ClassInfo> GetClassInfo();
    }
}
