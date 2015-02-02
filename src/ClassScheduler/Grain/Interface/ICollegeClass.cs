using System.Threading.Tasks;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface ICollegeClass : IGrainWithGuidKey
    {
        Task Configure(string name, string subject);
        Task AssignTeacher(ITeacher teacher);
        Task RegisterStudent(IStudent student);
        Task<string> GetName();
        Task<string> GetSubject();
        Task<ITeacher> GetTeacher();
        Task<int> GetClassSize();
    }
}
