# ProductManagementASPNETCoreMVC

Step 1: Build solution
# ProductManagementASPNETCoreMVC  

## Overview  
Welcome to the **ProductManagementASPNETCoreMVC** project! This application is designed to manage products efficiently using a modern ASP.NET Core MVC architecture.  

## Prerequisites  
Before you begin, ensure you have the following installed:  
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)  

## Getting Started  

### Step 1: Build the Solution  
1. Open the solution in Visual Studio.  
2. Build the solution to restore dependencies and ensure everything compiles.  

### Step 2: Configure the Database  
1. Navigate to the `Lab1` folder.  
2. Open the terminal in this directory. 
1. Configure your database connection string in the `appsettings.json` file. 
3. Run the following command to apply migrations and update the database:
> dotnet ef database update  

### Step 3: Run the Project  
1. Start the `ProductWebAPI` project.  
2. The application will launch, and you can test the API.  

### Step 4: Test the API  
- Open your browser and navigate to the Swagger UI (usually at `https://localhost:<port>/swagger`).  
- Use Swagger to explore and test the available API endpoints.  

## Features  
- **Product Management:** Create, read, update, and delete products.  
- **API Documentation:** Integrated Swagger UI for easy testing.  
- **Database Integration:** Powered by Entity Framework Core.  

## Troubleshooting  
- Ensure your database server is running and accessible.  
- Verify the connection string in `appsettings.json`.  

## License  
This project is licensed under the [MIT License](LICENSE).  

Enjoy building with **ProductManagementASPNETCoreMVC**!
Step 2: Click to Lab1 -> Open in Terminal
Step 3: Run command: dotnet ef database update
(Make sure you have installed the EF Core tools, if not, run command: dotnet tool install --global dotnet-ef)
(You can setting up your database connection string in appsettings.json file)

Ensured Database Created
Step 4: Run project ProductWebAPI
Step 5: Test API by Swagger

Enjoy it!

