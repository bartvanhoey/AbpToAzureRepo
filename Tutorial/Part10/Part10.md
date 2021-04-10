## Part 10: Release pipeline finished, Deployment [YourAppName].Blazor project succeeded, but Web App still not working. How to fix the issues?

  1. When the release is done and the deployment of your Blazor app succeeded, navigate to the URL of your Web App.
  
      ```html
      https://[YourAppName].azurewebsites.net
      ```  

  2. You probably receive a CORS related when trying to call the _api/abp/api-definition_ API endpoint.

      ![Cors error](Images\Images/blazor_deployment_succeeded_cors_issue.jpg)

  3. Add the blazor web app url to the _RedirectAllowedUrls_ section in *appsettings.Staging.json* of the *[YourAppName].HttpApi.Host* project.
  
      ```json
      "App": {
        "SelfUrl": "https://localhost:44321",
      " CorsOrigins": "https://*.AbpToAzure.com,https://localhost:44307",
        "RedirectAllowedUrls": "http://localhost:4200,https://localhost:44307,https://abpioazure.azurewebsites.net"
      },
      ```

  4. Open a command prompt in your project root folder. Add, Commit and Push your changes to the GitHub repository.

      ```html
      git add .
      git commit -m CorsSettings
      git push
      ```html

  5. Pushing changes to your GitHub repository triggers a new Build and when finished, a new Release should start
    7. After the Release, navigate to the URL of the Blazor Web App. You should see the index page of your Blazor Web App by now
    8. There is still another issue with the Web App when you click the Log in link to navigate to the login page. (Open the Developers Tools (F12)  to see the error description). You probably receive error *Refused to display ... in a frame because it set 'X-Frame-Options' to 'sameorigin'*
    <Figure Size="FigureSize.None">
      <FigureImage Source="images/refused_to_display_in_a_frame_because_it_set_X-Frame_Options_to_sameorigin.jpg" />
    </Figure>
    9. Add the code below in the *ConfigureServices* method of the *Startup.cs* file of the *[YourAppName].HttpApi.Host* project
    <pre><code class="language-html">
services.AddAntiforgery(options =>
{
    options.SuppressXFrameOptionsHeader = true;
});
    </code></pre>
    <Figure Size="FigureSize.None">
      <FigureImage Source="images/suppress_xframe_options_header.jpg" />
    </Figure>
    10. Add, Commit and push the changes to your GitHub repository
    11. Wait until the new Build and Release have finished. Navigate to the URL of your Blazor Web App
    12. The previous error *Refused to display ... in a frame because it set 'X-Frame-Options' to 'sameorigin'* is gone
    13. Now you probably get a *500 Error - unauthorized_client*. Still some issues with Identity Server?
    <Figure Size="FigureSize.None">
      <FigureImage Source="images/unauthorized_client.jpg" />
    </Figure>
    14. Set the *RootUrl* value in the *AbpIoAzureDevops_Blazor* section of the *appsettings.Staging.json* file of the *[YourAppName].DbMigrator* project to the URL of your Blazor Web App (https://[YourAppName]blazor.azurewebsites.net)
    15. Run the [YourAppName].DbMigrator project to apply the settings
    <Figure Size="FigureSize.None">
      <FigureImage Source="images/rooturl_appsettings_dbmigrator_project.jpg" />
    </Figure>
    16. Navigate to the URL of your Blazor Web App and click on the Log in link. The Login page gets loaded
    17. Fill in *Username (admin)* and *Password (1q2w3E*)* and click the Login button. Do you receive the error below?
    <Figure Size="FigureSize.None">
      <FigureImage Source="images/there_was_an_error_trying_to_log_you_in.jpg" />
    </Figure>
    18. Open the *appsettings.Staging.json* file of the *[YourAppName].HttpApi.Host* project and set the *App:SelfUrl* and *AuthServer:Authority* values to *https://[YourAppName]api.azurewebsites.net*
    19. Add, Commit and push the changes to your GitHub repository
    20. Wait until the Build and Release pipelines have finished. Navigate to the URL of your Blazor Web App. Click <b>Login</b>
    21. Fill in ** and *Password (1q2w3E*)* and click the <b>Login</b> button. Congratulations, You successfully logged in!
    22. Try to add a new user, logout and login with the newly created user to see if your ABP Framework application is working correctly



[Home](./../../README.md) | [Previous](Tutorial/../../Part9/Part9.md)