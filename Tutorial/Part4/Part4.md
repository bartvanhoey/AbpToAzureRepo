## Part 4: Setup the Build pipeline in AzureDevops and publish the Build Artifacts

1. Sign in into [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/).

2. Click on **New organization** and follow the steps to create a new organization. Name it *[YourAppName]Org*.

3. Enter *[YourAppName]Proj* in the *Project name* input field in the *Create a project to get started* window.

4. Select *Public* visibility and click the **Create project** button.

5. Click on the **Pipelines** button to continue

6. Click on the **Create Pipeline** button.

7. Click on **Use the classic editor** to create a pipeline without YAML in the *Where is your code?* window.

8. Select *GitHub* in the *Select source* window.

9. Enter *[YourAppName]GitHubConnection* in the *Connection name* input field and click on **Authorize using OAuth**.

10. Select your GitHub *[YourAppName]Repo* and click **Continue**.

11. Search for *ASP.NET Core* in the *Select a template* window.

12. Select the *ASP.NET Core* template and click the **Apply** button.

13. Enter *[YourAppName]BuildPipeline* in the pipeline *Name* input field and select *vs2017-win2016* in the *Agent Specification* dropdown.

14. Click on the **plus sign** to *Add a task to Agent job 1*.

15. Search for *Use .NET Core sdk*. Select the *Use .NET Core sdk* task and click on the **Add** button.

16. Drag and drop the *Use .NET Core sdk* task just before the *Restore* task.

17. Enter *5.0.x* in the *Version* input field.

18. Leave all the default settings for the other tasks in the pipeline.

19. Check *Enable continuous integration* in the *Triggers* tab menu.

20. Click on **Save & queue** in the tab menu. Click on **Save & queue** again and click **Save an run** to run the Build pipeline

21. When the Build pipeline has finished. Click **on 1 published; 1 consumed**

22. In the *1 published; 1 consumed* folder you should now have 2 zip Artifacts. 1 for the *[YourAppName].Blazor* project and 1 for the *[YourAppName].HttpApi.Host* project


[Home](./../../README.md) | [Previous](Tutorial/../../Part3/Part3.md) | [Next](Tutorial/../../Part5/Part5.md)