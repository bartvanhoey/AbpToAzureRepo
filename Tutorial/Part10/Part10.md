## Part 10: Release pipeline finished, Deployment [YourAppName].Blazor project succeeded, but Web App still not working. How to fix the issues?

  1. When the release is done and the deployment of your Blazor app succeeded, navigate to the URL of your Web App.
  
      ```html
      https://[YourAppName].azurewebsites.net
      ```  

  2. You probably receive a CORS error related when trying to call the _api/abp/api-definition_ API endpoint.

      ![Cors error](Images\Images/blazor_deployment_succeeded_cors_issue.jpg)

  3. Add the blazor web app url to the _RedirectAllowedUrls_ section in *appsettings.Staging.json* of the *[YourAppName].HttpApi.Host* project.
  
      ```json
      "App": {
        "SelfUrl": "https://localhost:44321",
      " CorsOrigins": "https://*.AbpToAzure.com,https://localhost:44307",
        "RedirectAllowedUrls": "http://localhost:4200,https://localhost:44307,https://[YourAppName].azurewebsites.net"
      },
      ```

  4. Open a command prompt in your project root folder. Add, Commit and Push your changes to the GitHub repository.

      ```html
      git add .
      git commit -m CorsSettings
      git push
      ```html

  5. Pushing changes to your GitHub repository triggers a new Build and when finished, a new Release should start.
  6. After the Release finishes, navigate to the URL of the Blazor Web App. You should see the index page of your Blazor Web App by now.
  7. There is still another issue with the Web App when you click the Log in link to navigate to the login page.
     (Open the Developers Tools (F12)  to see the error description). You probably receive error *Refused to display ... in a frame because it set 'X-Frame-Options' to 'sameorigin'*

      ![Refused to display in a frame because it set 'X-Frame-Options'](Images\refused_to_display_in_a_frame_because_it_set_X-Frame_Options_to_sameorigin.jpg)

  8. Add the code below in the *ConfigureServices* method of the *Startup.cs* file of the *[YourAppName].HttpApi.Host* project.

      ```csharp
      services.AddAntiforgery(options =>
      {
        options.SuppressXFrameOptionsHeader = true;
      });
      ```
  
  9. Add, Commit and push the changes to your GitHub repository.
  10. Wait until the new Build and Release have finished. Navigate to the URL of your Blazor Web App.
  11. The previous error *Refused to display ... in a frame because it set 'X-Frame-Options' to 'sameorigin'* is gone.
  12. Now you probably get a *500 Error - unauthorized_client*. Still some issues with Identity Server?

      ![500 Error - unauthorized_client'](Images\unauthorized_client.jpg)
  
  13. Set the *RootUrl* value in the *AbpIoAzureDevops_Blazor* section of the *appsettings.Staging.json* file of the *[YourAppName].DbMigrator* project to the URL of your Blazor Web App.

      ```json
      "IdentityServer": {
        "Clients": {
          "AbpIoAzureDevops_Blazor": {
            "ClientId": "AbpIoAzureDevops_Blazor",
            "ClientSecret": "1q2w3e*",
            "RootUrl": "https://[YourAppName].azurewebsites.net"
          }
        }
      ```
  
  14. Run the [YourAppName].DbMigrator project to apply the IdentityServer settings in the Staging Environment.
  15. Navigate to the URL of your Blazor Web App and click on the Log in link. The Login page gets loaded.
  16. Fill in *Username (admin)* and *Password (1q2w3E*)* and click the Login button. Do you receive the error below?

      ![There was an error trying to log you in](Images\there_was_an_error_trying_to_log_you_in.jpg)

  17. Open the *appsettings.Staging.json* file of the *[YourAppName].HttpApi.Host* project and set the *App:SelfUrl* and *AuthServer:Authority* values to the url of the API.
  18. Add, Commit and push the changes to your GitHub repository
  19. Wait until the Build and Release pipelines have finished. Navigate to the URL of your Blazor Web App. Click **Login**
  20. Fill in ** and *Password (1q2w3E*)* and click the **Login** button. Congratulations, You successfully logged in!
  21. Try to add a new user, logout and login with the newly created user to see if your ABP Framework application is working correctly

[Home](./../../README.md) | [Previous](Tutorial/../../Part9/Part9.md)
