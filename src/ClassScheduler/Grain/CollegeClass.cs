using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.Gain
{
    class CollegeClass : Grain, ICollegeClass
    {
        private string _subject;
        private string _name;

        public Task Configure(string name, string subject)
        {
            _name = name;
            _subject = subject;
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
    }
}
