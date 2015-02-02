using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    class Student : Grain, IStudent
    {
        private string _firstName;
        private string _lastName;

        public Task SetName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            return TaskDone.Done;
        }

        public Task<string> GetFullName()
        {
            string fullNAme = string.Format("{0} {1}", _firstName, _lastName);
            return Task.FromResult(fullNAme);
        }

        public Task<string> GetFirstName()
        {
            return Task.FromResult(_firstName);
        }

        public Task<string> GetLastName()
        {
            return Task.FromResult(_lastName);
        }
    }
}