using System.IO;
using Orleans.Host;

namespace Orleans.Samples.ClassScheduler.WebApp.Helper
{
    public class OrleansHelper
    {
        public static void EnsureOrleansClientInitialized()
        {
            if (!OrleansAzureClient.IsInitialized)
            {
                FileInfo clientConfigFile = AzureConfigUtils.ClientConfigFileLocation;
                if (!clientConfigFile.Exists)
                {
                    throw new FileNotFoundException(
                        string.Format("Cannot find Orleans client config file for initialization at {0}",
                            clientConfigFile.FullName), clientConfigFile.FullName);
                }
                OrleansAzureClient.Initialize(clientConfigFile);
            }
        }
    }
}