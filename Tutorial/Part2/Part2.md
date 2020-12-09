## Part 2: Create a new abp.io application

1. Check your dotnet version. Should be at least* 5.0.x.

   ````bash
   dotnet --version
   ````

2. Install or update first the [ABP CLI](https://docs.abp.io/en/abp/latest/CLI) using a command line window.

   ```bash
   dotnet tool install -g Volo.Abp.Cli || dotnet tool update -g Volo.Abp.Cli
   ```

3. Open a command prompt in the *GitHub repository folder* and create a *new abp Blazor* solution with the command below.

   ```bash
   abp new YourAppName -u blazor
   ```

4. Rename the *aspnet-core* folder to [YourAppName].

5. Open a command prompt in the [YourAppName].DbMigrator project and run the `dotnet run` to apply the database migrations.

   ```bash
   dotnet run
   ```

6. Open a command prompt in the [YourAppName].HttpApi.Host project to run the API project.

   ```bash
   dotnet run
   ```

7. Navigate to the *applicationUrl* specified in the *launchSettings.json* file of the [YourAppName].HttpApi.Host project. You should get the SwaggerUI window.

8. Open a command prompt in the [YourAppName].Blazor folder and enter the command below to run the Blazor project.
  
   ```bash
   dotnet run
   ```

9. Navigate to the *applicationUrl* specified in the *launchSettings.json* file of the [YourAppName].Blazor project. You should get the ABP.IO Welcome window.

10. Stop both the API and the Blazor project by pressing `CTRL+C`.

11. Open a command prompt in the root folder of your project and add, commit and push all your changes to your GitHub repository.

  ```bash
  git add .
  git commit -m IinitialCommit
  git push
  ```

[Previous](Tutorial/../../Part1/Part1.md) | [Next](Tutorial/../../Part3/Part3.md)