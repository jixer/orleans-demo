Add Server configuration file: https://github.com/dotnet/orleans/blob/master/Samples/AzureWebSample/OrleansAzureSilos/OrleansConfiguration.xml
Add client configuration: https://github.com/dotnet/orleans/blob/master/Samples/AzureWebSample/WebRole/ClientConfiguration.xml
Setup cloud configurations
<Setting name="DataConnectionString" value="DefaultEndpointsProtocol=https;AccountName=MYACCOUNTNAME;AccountKey=MYACCOUNTKEY" />

Setup definition w/ endpoints: 11111 (OrleansSiloEndpoint) & 30000 (OrleansProxyEndpoint)
Setup startup command line counter control: 
	<Task commandLine="CounterControl.exe" executionContext="elevated" taskType="simple" />

Setup worker role startup:
https://github.com/dotnet/orleans/blob/master/Samples/AzureWebSample/OrleansAzureSilos/WorkerRole.cs

Setup local storage: LocalStoreDirectory


Fix assembly bindings:
	  <runtime>
		<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
		  <dependentAssembly>
			<assemblyIdentity name="Microsoft.WindowsAzure.Configuration" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
			<bindingRedirect oldVersion="0.0.0.0-2.0.0.0" newVersion="2.0.0.0"/>
		  </dependentAssembly>
		  <dependentAssembly>
			<assemblyIdentity name="Microsoft.WindowsAzure.Diagnostics" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
			<bindingRedirect oldVersion="0.0.0.0-2.5.0.0" newVersion="2.5.0.0"/>
		  </dependentAssembly>
		  <dependentAssembly>
			<assemblyIdentity name="Microsoft.WindowsAzure.ServiceRuntime" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
			<bindingRedirect oldVersion="0.0.0.0-2.5.0.0" newVersion="2.5.0.0"/>
		  </dependentAssembly>
		  <dependentAssembly>
			<assemblyIdentity name="Microsoft.WindowsAzure.StorageClient" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
			<bindingRedirect oldVersion="0.0.0.0-1.7.0.0" newVersion="1.7.0.0"/>
		  </dependentAssembly>
		</assemblyBinding>
	  </runtime>
