using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans.Providers;
using Orleans.Samples.ClassScheduler.Data;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    [StorageProvider(ProviderName = "AzureStore")]
    class CollegeClass : Grain<IClassState> , ICollegeClass
    {
        public Task Configure(string name, string subject)
        {
            State.Name = name;
            State.Subject = subject;
            return State.WriteStateAsync();
        }

        public Task AssignTeacher(Guid teacherId)
        {
            State.Teacher = teacherId;
            return State.WriteStateAsync();
        }

        public Task RegisterStudent(Guid studentId)
        {
            if (State.Students == null) State.Students = new List<Guid>();
            State.Students.Add(studentId);
            return State.WriteStateAsync();
        }

        public Task<string> GetName()
        {
            return Task.FromResult(State.Name);
        }

        public Task<string> GetSubject()
        {
            return Task.FromResult(State.Subject);
        }

        public Task<ClassInfo> GetClassInfo()
        {
            var classInfo = new ClassInfo()
            {
                Name = State.Name,
                Subject = State.Subject,
                Teacher = State.Teacher,
                Students = State.Students
            };

            return Task.FromResult(classInfo);
        }
    }
}
