using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    class CollegeClass : Grain, ICollegeClass
    {
        private string _subject;
        private string _name;
        private ITeacher _teacher;
        private IList<IStudent> _students = new List<IStudent>();

        public Task Configure(string name, string subject)
        {
            _name = name;
            _subject = subject;
            return TaskDone.Done;
        }

        public Task AssignTeacher(ITeacher teacher)
        {
            _teacher = teacher;
            return TaskDone.Done;
        }

        public Task RegisterStudent(IStudent student)
        {
            _students.Add(student);
            return TaskDone.Done;
        }

        public Task<string> GetName()
        {
            return Task.FromResult(_name);
        }

        public Task<string> GetSubject()
        {
            return Task.FromResult(_subject);
        }

        public Task<ITeacher> GetTeacher()
        {
            return Task.FromResult(_teacher);
        }

        public Task<int> GetClassSize()
        {
            return Task.FromResult(_students.Count);
        }
    }
}
