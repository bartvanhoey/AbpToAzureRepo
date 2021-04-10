## Part 7: Release pipeline finished, API deployment succeeded. Web App not working! How to fix the issues?

  1. When the Release pipeline has finished and the Deployment of the API succeeded, open a browser window and navigate to the URL of your Web App.
  
      ```html
      https://[YourAppName]api.azurewebsites.net
      ```

  2. It's possible that you receive the error *HTTP Error 500.30 - ANCM In-Process Start Failure*.
  
      ![HTTP Error 500.30 - ANCM In-Process Start Failure](Images/HTTP_Error_500.30_ANCM_In_Process_Start_Failure.jpg)

  3. Open the *Debug Console/CMD* in the *Kudu* window by navigating to *[YourAppName]api.scm.azurewebsites.net*.

      ```html
      https://[YourAppName]api.scm.azurewebsites.net
      ```

  4. Run the *dir* command to heck if [YourAppName].HttpApi.Host files have been deployed in the *home\site\wwwroot* folder.

      ```bash
      dir
      ```

  5. Check the dotnet version of the Azure Web App. Should be 5.0.x.

      ```bash
      dotnet --version
      ```

      ![Kudu check dotnet version](Images/kudu_debug_console_check_dotnet_version.jpg)

  6. To solve error *HTTP Error 500.30 - ANCM In-Process Start Failure* update the [YourAppName].HttpApi.Host.csproj file.

      ```bash
        <PropertyGroup>
          <TargetFramework>net5.0</TargetFramework>
          // add the line below
          <AspNetCoreHostingModel>OutOfProcess</AspNetCoreHostingModel>
          <RootNamespace>AbpToAzure</RootNamespace>
          <PreserveCompilationReferences>true</PreserveCompilationReferences>
          <UserSecretsId>AbpToAzure-4681b4fd-151f-4221-84a4-929d86723e4c</UserSecretsId>
        </PropertyGroup>
      ```
  
  7. Open a command prompt in the root folder of your project and Add, Commit and Push all your changes to your GitHub repository.

      ```bash
      git add .
      git commit -m OutOfProcess
      git push
      ```

  8. Pushing to your GitHub repository will trigger a *new Build* as *Continuous Integration* is enabled in the Build pipeline.

  9. When the Build finishes, a new Release will start. Wait until the Release has finished and the Deployment Succeeded.
  
  10. Navigate to the URL of the Web App. You probably see the error *An error occurred while starting the application.*.

      ![An error when starting the application](Images/an_error_when_starting_the_application.jpg)
  
  11. Open the *Debug Console/CMD* in the *Kudu* window by navigating to [YourAppName]api.scm.azurewebsites.net.

      ```html
      https://[YourAppName]api.scm.azurewebsites.net
      ```

  12. Try to invoke an *error description* by entering the command below in the *home/site/wwwroot* folder of the *Debug Console*.

      ```html
      dotnet [YourAppName].HttpApi.Host.dll
      ```

  13. If you receive no Error description. Go to *Program.cs* in the *[YourAppName].HttpApi.Host* project and comment out the *if debug statements*.

      ```csharp public class Program
      {
          public static int Main(string[] args)
          {
              Log.Logger = new LoggerConfiguration()

      // #if DEBUG
                      .MinimumLevel.Debug()
      // #else
                      .MinimumLevel.Information()
      // #endif
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                      .Enrich.FromLogContext()
                      .WriteTo.Async(c => c.File("Logs/logs.txt"))
      // #if DEBUG
                      .WriteTo.Async(c => c.Console())
      // #endif
                      .CreateLogger();
      // other code here ...
      ```

  1.  Add, Commit and Push all your changes to your GitHub repository.
 ```html
git add .
git commit -m CommentOutDebugStatements
git push
```
15. Wait until the new Build and new Release have finished and the Deployment has succeeded.
16. Navigate to the URL of the Web App. You should see the same error *An error occurred while starting the application.* again.
 17. Open the *Debug Console* in the *Kudu* window by navigating to [YourAppNameapi].scm.azurewebsites.net.
```htmlhttps://[YourAppName]api.scm.azurewebsites.net```
18. Enter the command below in the wwwroot folder of the *Debug Console* to start the application. Now you should see the detailed error description. The file *tempkey.rsa* is missing.
```htmldotnet [YourAppName].HttpApi.Host.dll```
<Figure Size="FigureSize.None">
  <FigureImage Source="images/could_not_find_file_tempkey.rsa.jpg" />
</Figure>
19. Add the section below to the *[YourAppName].HttpApi.Host.csproj* file to copy the *missing tempkey.rsa* file to the output directory .
```html
&lt;ItemGroup&gt
&lt;None Update="tempkey.rsa"&gt
&lt;CopyToOutputDirectory&gtPreserveNewest&lt;/CopyToOutputDirectory&gt
&lt;/None&gt
&lt;/ItemGroup&gt
```
20. Add, Commit and Push all your changes to your GitHub repository.
```html
git add .
git commit -m CopyToOutputDirectory
git push
```
21. Wait until the new Build and Release have finished and the Deployment has succeeded.
22. Navigate to the URL of the Web App to see if the error is gone.
23. It's possible that you get another error: *This page isn’t working*.
24. Open the *Debug Console* in the *Kudu* window by navigating to *[YourAppNameapi].scm.azurewebsites.net*.
```htmlhttps://[YourAppName]api.scm.azurewebsites.net```
25. Enter the command below in the *wwwroot* folder of the *Debug Console* to get a more specific error description.
```htmldotnet [YourAppName].HttpApi.Host.dll```
26. Probably you receive the error description below.
<Figure Size="FigureSize.None">
  <FigureImage Source="images/client_not_allowed_to_access_server.jpg" />
</Figure>
27. Go to your *Azure Portal* and select your *[YourAppName]server*.
28. Click on <b>Firewalls and virtual networks</b> in the left menu.
29. Select <b>Yes</b> in the *Allow Azure services and resources to access this server* toggle.
30. Click the <b>Save</b> button. Click <b>OK</b> in the *Successfully updated server firewall rules* window. Close the window .
31. Navigate to the URL of the Web App and Refresh the page.
32. Your *[YourAppName].HttpApi.Host* project should now <b>be up and running</b> and the *Swagger* page is served by your Web App in Azure.
<Figure Size="FigureSize.None">
  <FigureImage Source="images/swagger_page_served_by_web_app_on_azure.jpg" />
</Figure>



[Home](./../../README.md) | [Previous](Tutorial/../../Part6/Part6.md) | [Next](Tutorial/../../Part8/Part8.md)
