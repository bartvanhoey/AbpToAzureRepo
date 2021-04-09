## Part 3: Create Azure SQL Database and change connection string in appsettings.Staging.json

1. Login into the [Azure Portal](https://portal.azure.com/#home).

2. Click on **Create a resource**.

3. Search for *SQL Database*.

4. Click the **Create** button in the *SQL Database window*.

5. Create a new resource group. Name it *rg[YourAppName]*.

6. Enter *[YourAppName]Db* as database name.

7. Click **Create new** to create a new Server and name it *[yourappname]server*.

8. Enter a *Server admin login*, *passwords* and select your *Location*. Click the **OK** button.

9. Click on **Configure database**. Go for the Basic version and click the **Apply** button

10. Click the **Review + create** button. Click **Create**.

11. Click on **Go to resource** when the SQL Database is created.

12. Click **Set server firewall** tab menu item.

13. Click on **Add client IP** tab menu item and click the **Save** and **OK** buttons next.

14. Close the Firewall settings window.

15. Click on **Show database connection strings** and copy the connection string

16. Copy/paste the *appsettings.json* file and rename it to *appsettings.Staging.json* in both the *YourAppName].HttpApi.Host* and *[YourAppName].DbMigrator* project.

17. Replace the *Default connection* string in the *appsettings.Staging.json* files of both the *[YourAppName].HttpApi.Host* and *[YourAppName].DbMigrator* project.

18. Do not forget to replace {your_password} with the correct server password you entered in Azure.

19. Open file *DbMigratorHostedService.cs* in the *[YourAppName].DbMigrator* project and update the code.

    ```csharp
    // Using statements needed
    using Microsoft.Extensions.Configuration;
    using System;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var application = AbpApplicationFactory.Create<ConplementAGDbMigratorModule>(options =>
        {
        options.UseAutofac();
        options.Services.AddLogging(c => c.AddSerilog());
  
        // Add this line of code to make it possible read from appsettings.Staging.json
        options.Services.ReplaceConfiguration(BuildConfiguration());
  
        }))
        {
        application.Initialize();
  
        await application
            .ServiceProvider
            .GetRequiredService<ConplementAGDbMigrationService>()
            .MigrateAsync();
  
        application.Shutdown();
  
        _hostApplicationLifetime.StopApplication();
        }
    }
  
    private static IConfiguration BuildConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
  
        // Extra code block to make it possible to read from appsettings.Staging.json
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environmentName == "Staging")
        {
        configurationBuilder.AddJsonFile($"appsettings.{environmentName}.json", true);
        }
  
        return configurationBuilder
            .AddEnvironmentVariables()
            .Build();
    }
    ```

20. Open the file *[YourAppName].DbMigrator.csproj* and copy/paste in the code below.

     ```html
     <ItemGroup>
      <Content Include="appsettings.Staging.json">
          <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
          <CopyToOutputDirectory>Always</CopyToOutputDirectory>
      </Content>
     </ItemGroup>
     ```

21. Run the *DbMigratorStaging* configuration from the *Debug window* to apply the database migrations to the database in Azure.

22. After the database migrations have completed, run the *ApiStaging* configuration from the *Debug window* to run the *[YourAppName].HttpApi.Host* project.
    Your API runs now locally but uses the *[YourAppName]Db* on Azure.

23. Replace your password in the appsettings.Staging.json files with {your_password} as you don't want to publish them on GitHub.

24. Update the *Nuget.Config* file in the root of your project. Otherwise the Build pipeline in the next part won't find some nuget packages.

```html
<configuration>
  <packageSources>
    <add key="BlazoriseMyGet" value="https://www.myget.org/F/blazorise/api/v3/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

25. Open a command prompt in the root folder of your project and add, commit and push all your changes to your GitHub repository.

    ```bash
    git add .
    git commit -m Part3Completed
    git push
    ```

[Home](./../../README.md) | [Previous](Tutorial/../../Part2/Part2.md) | [Next](Tutorial/../../Part4/Part4.md)