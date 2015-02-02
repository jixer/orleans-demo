using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    class CollegeClass : Grain, ICollegeClass
    {
        private string _subject;
        private string _name;
        private Guid _teacher;
        private IList<Guid> _students = new List<Guid>();

        public Task Configure(string name, string subject)
        {
            _name = name;
            _subject = subject;
            return Task.FromResult(0);
        }

        public Task AssignTeacher(Guid teacherId)
        {
            _teacher = teacherId;
            return Task.FromResult(0);
        }

        public Task RegisterStudent(Guid studentId)
        {
            _students.Add(studentId);
            return Task.FromResult(0);
        }

        public Task<string> GetName()
        {
            return Task.FromResult(_name);
        }

        public Task<string> GetSubject()
        {
            return Task.FromResult(_subject);
        }

        public Task<ClassInfo> GetClassInfo()
        {
            var classInfo = new ClassInfo()
            {
                Name = _name,
                Subject = _subject,
                Teacher = _teacher,
                Students = _students
            };

            return Task.FromResult(classInfo);
        }
    }
}
