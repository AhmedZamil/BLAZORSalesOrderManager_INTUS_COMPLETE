# BLAZOR Sales Order Manager INTUS
Task For Developer Blazor NET Core

# Developer TASK [BLAZOR WASM] INTUS - Technical Challenge

 ## Delevery /Task Complete : 
Setup shortcut [Checked with different machine]It's Just to setup to all done Now.
 
    ## 1. Run the Setup.bat file (Will set up everything to run locally )
    ## 2. After Running just browse https://localhost:7039/ 
    ## 3. My Task is Deployed and LIVE ! Browse : https://intusblazorsalesordermanagerapp.azurewebsites.net/
    
[It will ensure navigate & install dependency  for dotnet restore, installing dotnet ef ,add migration , update database , build & run the application with Provided Seed data .Just aloow the Setup.bat file sometime to do that , upto when it shows "Building..."]

 * Note : you will find the details below if you want to run development enviourment [Visual Studio 2022] 
 * Note : you will find the Navigation to application to say how to browse application sections & what they do
 * Note : to achieve better presentation I have deployed the application in Azure, You can browse it

## Developer Task & Requerments :

Task Description

Create a web app, for managing sales order data.

Requirements
1. Create new database tables Using Code First In Entity Framework.
2. Blazor WebAssembly app with an interface to show data from DB.
3. Make an ability to change and save data in the application: state, name, and dimensions.
4. Add the ability to create and delete orders, windows and elements.
5. Optional: Interface validations. DTO. Separated BLL and DAL projects.

Bonus points:
Use of the best practices and Oriented Object Programming
Short time to finish and get back to us
Appearence

Architecture:
BLAZOR Web Assembly 
.NET Core 6
SQL Server using Entity Framework 6 and LocalDB


## Delevery / TASK Submission : Details

# Domain Requirement 
Requirements Covered :
   1. Yes ,Database has been created Using Code First In Entity Framework.
     a.Provided Sample data has been seeded for initial execution.
   2. Created Blazor WebAssembly app with an interface to show data from DB.
     a.It's Blazor WebAssembly App.
     b.UI with Blazor with Pages,Component,Widget,Navigation.
     c.WEB API is Interfacing the Application Backend (.NET Core Web API)
     d.Data is Comming through API , Service , Repository from SQL DB using EF 6
   3. Make an ability to change and save data in the application: state, name, and dimensions.
     a.Change/Modify/Edit for Data is implemented.
     b.You can Change state,name,dimension.
     c.You can even Edit Order
     d.You can Romove - Edit Windows from Order.
     e.You can add Windows to order
     
     i.You can even Edit Windows
     ii.You can Romove - Edit Sub Element from Window.
     ii.You can  add Sub Element to Window 
   4. Add the ability to create and delete orders, windows and elements.
     a.Order :You can even Create/View/Remove/Edit New.
     d.Window: You can even Create/View/Remove/Edit New.
     c.Sub Element: You can even Create/View/Remove/Edit New.
     
   5. Optional: Interface validations. DTO. Separated BLL and DAL projects.
     a. Validation For Basic Requiered Fields with other validation
     b.Domain Models are in seperate .NET Core project
     c.Repositories are in seperate .NET Core project
     d. Services are in seperate .NET Core Project
     e. WEB API is in seperate .NET Core web API project.But when you run API other than using OPEN API for documentation I used to boot UI app.Just to make it compact       & easy to deploy in Azure.
     f.UI (BLAZOR ) is in seperate WASM implemented project

NOTE : Here BLAZOR WEB Assembly need API/INTERFACE to communicate/Feed data.It could have been a Seperated Pr 


# Technologies
 - BLAZOR WebAssembly
 - All project built on Latest .NET Core 6.0 
 - EF 6
 - Local DB [MS Sql Server]

# Good to share 
  - I have tried to have the best possible impression , thats why took time to polish & beutify
  - Tried to maintain n-tier Architecture along with Repository pattern.
  - Tried to maintain S O L I D
     - Interface are segragated
     - rather than a whole Scope tried to use one responsibility for single scope
     - ASP.NET Core Web API are to feed (to be honest not Restful in many ways)
  - I Could Have use Authentication/Authorization with Auth0 ( But seems it will be overdone/ not understanding the requierment like)
  - I Could Have to Use JWT Bearer to Autheticate & generate token (For best impression)
  - Uses Interface - Repository Pattern (Mixed N-tier)

# Prerequisites ( If some body want's to take the code in visual studio)

## Only [.NET Core 6.0 SDK] (https://dotnet.microsoft.com/download) has to be present to Run
## After running setup file , give it some time [after setting up npm-EF-Db-Seed data When it shows "Building" just browse http://localhost:5000/]

If you want to open in developer mode 

* [Visual Studio 2022] (https://visualstudio.microsoft.com/vs/)

If you clone the repo, want to run the code in devlopment mode in visual studio

In Visual Studio 2022:

step 1 : clone the repository

step 2: have Prerequisites

step 3: open the solution file in visual studio 2022

step 4: go to command prompt terminal

step 5: run command to check ,  dotnet --version (it has to be ASP.NET Core 6.0)

step 6 : run command dotnet restore or clean the solution clean the project and  - build

step 7: make sure you setup the database and Entity Framework migrations!
This is how:
      1. Remove the contents of the folder Migrations.
      2. Then open the Package Manager Console (Tools->Nuget Package Manager->Package Manager Console).
      3. Run the following commands:

          Add-Migration Initial
          Update-Database
 
 
 step 12: run the solution [either with F5 or dotnet run ]

 step 13: Application should be in web browser
 
 
 # Navigation through the application
 


5) run the setup.bat file (you wil find it in current working directory)
   it does the below steps 

   - dotnet restore will restore all dependecis
   - dotnet build will build the project
   - check dotnet ef installed or not
    -if not will install globally
    - will create & update database according to migration
    - dotnet run will seed initial data 
    - application should be running in local IIS

