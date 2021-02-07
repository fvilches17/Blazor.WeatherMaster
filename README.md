# Introduction 
This is a project to demonstrate how Blazor can be used by .NET teams to boost their productivity when writing web applications  

Moreover, this project is a PoC to try out [Syncfusion Blazor Components](https://www.syncfusion.com/blazor-components)

# Getting Started (Run solution on local machine)

## Pre-Requisites
1. Install .Net5 on your machine. [Download Link](https://dotnet.microsoft.com/download/dotnet/5.0). This applies if you're using VSCode for Dev.
1. Make sure you have the the latest version of [Visual Studio](https://visualstudio.microsoft.com/downloads/). By downloading the latest, you get .Net5 automatically
2. Add your Syncfusion key to the appsettings.Development.json file. In order to get a paid or trail key, check out Syncfusion getting started [doc](https://blazor.syncfusion.com/documentation/getting-started/server-side-blazor/?_ga=2.86898904.1114893659.1612691632-1136824193.1610842117)

## Steps
1. Clone the repository from [here](https://dev.azure.com/vmob/New%20Plexure/_git/FrontEndTournament.Blazor)
2. In Visual Studio, open the Solution (.sln file), choose WeatherMaster.csproj as your startup project, and hit CTRL+F5 or F5
2. If using VSCode/CLI, run the dotnet run command inside the same folder as the `WeatherMaster.csproj` file
3. That's it! the app will open up on your default browser

# Build and Test
This app is deployed to Plexure's Azure Cloud. This repository has an Infrastructure folder containing all necessary files to automate deployment
- ARM Templates
- ARM Template parameters
- YAML Pipeline file

Whenver there code push to the `Main` branch this [CI / CD Pipeline](https://dev.azure.com/vmob/New%20Plexure/_build?definitionId=736) will get automatically triggered.  

The pipeline runs tests. So granted all tests are passing, the development environment will get deployed.

# Environments
* https://dev-blazorweathermaster.azurewebsites.net/
* https://qa-blazorweathermaster.azurewebsites.net/

# Blazor Learning Resources
* https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
* https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-5.0