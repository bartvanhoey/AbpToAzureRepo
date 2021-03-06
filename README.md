# ABP Framework to Azure!

## Continuous Deployment of an ABP Framework application with Azure DevOps

A **step-by-step** tutorial on how to set up **Continuous Deployment in Azure DevOps** of an **ABP Framework** application

[![Build Status](https://dev.azure.com/AbpToAzureOrg/AbpToAzure/_apis/build/status/AbpToAzureBuildPipeline?branchName=gh-pages)](https://dev.azure.com/AbpToAzureOrg/AbpToAzure/_build/latest?definitionId=1&branchName=gh-pages)

To follow along you need .NET 5.x and ABP Framework v4.x installed. I use Visual Studio Code as code editor.

[Part 1: Create a new GitHub repository](Tutorial/Part1/Part1.md)

[Part 2: Create a new ABP Framework application](Tutorial/Part2/Part2.md)

[Part 3: Create Azure SQL Database and change connection string in appsettings.Staging.json](Tutorial/Part3/Part3.md)

[Part 4: Setup the Build pipeline in AzureDevops and publish the Build Artifacts](Tutorial/Part4/Part4.md)

[Part 5: Create Web App in Azure Portal to deploy [YourAppName].HttpApi.Host project](Tutorial/Part5/Part5.md)

[Part 6: Create Release pipeline in AzureDevops and deploy [YourAppName].HttpApi.Host project](Tutorial/Part6/Part6.md)

[Part 7: Release pipeline finished, API deployment succeeded. Web App not working! How to fix the issues?](Tutorial/Part7/Part7.md)

[Part 8: Create a Web App in the Azure Portal to deploy [YourAppName].Blazor project](Tutorial/Part8/Part8.md)

[Part 9: Add extra Stage in the Release pipeline in AzureDevops to deploy [YourAppName].Blazor project](Tutorial/Part9/Part9.md)

[Part 10: Release pipeline finished, Blazor deployment succeeded. Web App not working! How to fix the issues?](Tutorial/Part10/Part10.md)
