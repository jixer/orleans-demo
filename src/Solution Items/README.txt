Add Server configuration file: https://github.com/dotnet/orleans/blob/master/Samples/AzureWebSample/OrleansAzureSilos/OrleansConfiguration.xml
Add client configuration: https://github.com/dotnet/orleans/blob/master/Samples/AzureWebSample/WebRole/ClientConfiguration.xml
Setup cloud configurations
<Setting name="DataConnectionString" value="DefaultEndpointsProtocol=https;AccountName=MYACCOUNTNAME;AccountKey=MYACCOUNTKEY" />

Setup definition w/ endpoints: 11111 & 30000
Setup startup command line counter control: 
	<Task commandLine="CounterControl.exe" executionContext="elevated" taskType="simple" />

Setup worker role startup:
https://github.com/dotnet/orleans/blob/master/Samples/AzureWebSample/OrleansAzureSilos/WorkerRole.cs