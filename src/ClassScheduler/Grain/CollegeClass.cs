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
        private ICollegeClass _me;

        public override Task ActivateAsync()
        {
            _me = GrainFactory.GetGrain<ICollegeClass>(this.GetPrimaryKey());
            return base.ActivateAsync();
        }

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

        public async Task RegisterStudent(IStudent student)
        {
            if (State.Students == null) State.Students = new List<IStudent>();
            State.Students.Add(student);
            await student.Enroll(_me);
            await State.WriteStateAsync();
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
                Teacher = State.Teacher
            };

            return Task.FromResult(classInfo);
        }

        public Task<IList<IStudent>> GetStudents()
        {
            return Task.FromResult(State.Students);
        }
    }
}
