using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    class Teacher : Grain, ITeacher
    {
        private string _firstName;
        private string _lastName;

        public Task SetName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            return Task.FromResult(0);
        }

        public Task<TeacherInfo> GetInfo()
        {
            var teacherInfo = new TeacherInfo()
            {
                FirstName = _firstName,
                LastName = _lastName
            };
            return Task.FromResult(teacherInfo);
        }

        public Task<string> GetFullName()
        {
            string fullNAme = string.Format("{0} {1}", _firstName, _lastName);
            return Task.FromResult(fullNAme);
        }
    }
}