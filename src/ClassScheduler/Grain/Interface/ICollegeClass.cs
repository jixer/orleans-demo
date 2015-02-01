using System.Threading.Tasks;

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    public interface ICollegeClass : IGrainWithGuidKey
    {
        Task Configure(string name, string subject);
        Task<string> GetName();
        Task<string> GetSubject();
    }
}
