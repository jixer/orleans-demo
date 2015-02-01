using System;
using Orleans.Samples.ClassScheduler.Gain.Interface;

namespace Orleans.Samples.ClassScheduler.StandaloneSilo
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // The Orleans silo environment is initialized in its own app domain in order to more
            // closely emulate the distributed situation, when the client and the server cannot
            // pass data via shared memory.
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                AppDomainInitializerArguments = args,
            });

            Orleans.OrleansClient.Initialize("DevTestClientConfiguration.xml");

            var classGuid = new Guid("49655b03-6eef-4f6e-a2ec-12357fb3fe10");

            Console.WriteLine("Orleans Silo is running.\nPress Enter to continue...");
            Console.ReadLine();

            var collegeClass = GrainFactory.GetGrain<ICollegeClass>(classGuid);
            collegeClass.Configure("Calculus 101", "MAT");
            Console.WriteLine("Class configured.\nPress Enter to continue...");
            Console.ReadLine();

            var collegeClass2 = GrainFactory.GetGrain<ICollegeClass>(classGuid);
            string name = collegeClass2.GetName().Result;
            string subject = collegeClass2.GetSubject().Result;
            Console.WriteLine("Retrieved class information (Name: {0}, SUbject: {1}).\nPress any key to continue...",
                name, subject);
            Console.ReadKey();

            Console.WriteLine("Test complete.\nPress Enter to terminate...");
            Console.ReadLine();
            hostDomain.DoCallBack(ShutdownSilo);
        }

        static void InitSilo(string[] args)
        {
            hostWrapper = new OrleansHostWrapper(args);

            if (!hostWrapper.Run())
            {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        static void ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }

        private static OrleansHostWrapper hostWrapper;
    }
}
