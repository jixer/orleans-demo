using System.Threading.Tasks;
using Orleans.Providers;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    [StorageProvider(ProviderName = "AzureStore")]
    class Student : Grain<IStudentState>, IStudent
    {
        public Task SetName(string firstName, string lastName)
        {
            State.FirstName = firstName;
            State.LastName = lastName;
            return State.WriteStateAsync();
        }

        public Task<StudentInfo> GetInfo()
        {
            var studentInfo = new StudentInfo()
            {
                FirstName = State.FirstName,
                LastName = State.LastName
            };
            return Task.FromResult(studentInfo);
        }

        public Task<string> GetFullName()
        {
            string fullNAme = string.Format("{0} {1}", State.FirstName, State.LastName);
            return Task.FromResult(fullNAme);
        }
    }
}