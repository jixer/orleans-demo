Add storage proiver reference
Update provider in Orleans Configurations (service): 
    <StorageProviders>
      <Provider Type="Orleans.Storage.AzureTableStorage"
                      Name="AzureStore"
                      DataConnectionString="UseDevelopmentStorage=true" />
    </StorageProviders>

Add storage interfaces

Update grains
	Use state
		Grain<IState>
		State.xxx = ""
		
	Add class attribute
		[StorageProvider(ProviderName = "AzureStore")]

Update controller creates to wait for result