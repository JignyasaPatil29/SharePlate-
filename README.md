SharePlate – Food Surplus and Donation Management System

A College Mini-Project using ASP.NET Core MVC, Entity Framework Core, and MySQL

SharePlate is a web-based application designed to help manage surplus food donations from restaurants, college canteens, hostels, and other food providers. It provides a centralized platform to record food donations, manage quantities, specify pickup deadlines, and track donation status.

The project demonstrates the implementation of the Model–View–Controller (MVC) architecture, database connectivity, CRUD operations, form handling, model validation, state management, and a responsive user interface.

1. Problem Statement

A significant amount of edible food can go to waste in restaurants, hostels, and college canteens, while people and organizations may need access to surplus food. Managing donation information manually can make it difficult to coordinate quantities, pickup locations, deadlines, and collection status.

SharePlate aims to organize food donation records in a centralized web application, making donation information easier to maintain and track.

2. Objectives
Develop a web application for managing surplus food donations.
Implement ASP.NET Core MVC architecture.
Connect the application to MySQL using Entity Framework Core.
Perform Create, Read, Update, and Delete (CRUD) operations.
Validate user input using model validation.
Manage application state using session and TempData.
Provide a responsive interface using Bootstrap.
Maintain project source code using Git and GitHub.
3. Technology Stack
Component	Technology
Programming language	C#
Web framework	ASP.NET Core MVC
ORM	Entity Framework Core
Database	MySQL
MySQL provider	Pomelo.EntityFrameworkCore.MySql
Frontend	HTML, CSS, JavaScript
UI framework	Bootstrap
Development environment	Visual Studio Code
Version control	Git
Code hosting	GitHub
4. Features and Modules
Donation Management
Add new food donation records.
View all available donation records.
View individual donation details.
Edit existing donation information.
Delete donation records after confirmation.
Donation Information

Each donation record can include:

Food name
Quantity in meals
Donor name
Pickup location
Pickup deadline
Donation status
Optional description
Record creation timestamp
Status Management

Donation statuses include:

Available
Reserved
Picked Up
Completed

The current application supports recording and filtering by status. A complete multi-user reservation workflow can be added as a future enhancement.

Validation and State Management
Required-field and range validation.
Server-side form validation.
Pickup deadline validation.
TempData success notifications.
Session-based donation status filtering.
Responsive User Interface

The application uses Bootstrap to support a clean interface across desktop and smaller screens.

5. System Architecture

SharePlate follows the Model–View–Controller architecture.

Model

Donation.cs defines the donation data and validation rules.
ApplicationDbContext.cs manages the database connection and entity mapping.

View

Razor views display donation lists, forms, details, and confirmation pages.
Bootstrap provides responsive styling.

Controller

DonationsController.cs processes incoming requests, validates submitted data, and performs database operations.

Database

MySQL stores donation records.
Entity Framework Core maps C# entities to database tables.
EF Core migrations manage database schema changes.
Request Flow

User / Browser → MVC Controller → Entity Framework Core → MySQL Database

MySQL query results return through the controller to the Razor view, which displays the updated information.

6. Database Design
Donations Table
Column	Description
Id	Primary key
FoodName	Name of the food
Quantity	Number of meals
DonorName	Name of the food donor
PickupLocation	Collection location
PickupDeadline	Pickup deadline
Status	Current donation status
Description	Optional details
CreatedAt	Record creation timestamp

The database also contains __EFMigrationsHistory, which Entity Framework Core uses to track applied migrations.

7. Project Structure
text
SharePlate/
├── Controllers/
│   └── DonationsController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Migrations/
├── Models/
│   └── Donation.cs
├── Properties/
├── Views/
│   ├── Donations/
│   ├── Shared/
│   └── _ViewImports.cshtml
├── wwwroot/
├── Program.cs
├── SharePlate.csproj
├── appsettings.json
├── .gitignore
└── README.md


The exact files may vary slightly depending on the project template and installed packages.

8. Prerequisites

Install or configure the following before running the project:

A compatible .NET SDK
Visual Studio Code
MySQL Server
MySQL Workbench
Git
Entity Framework Core CLI (dotnet-ef)

Check the installed .NET SDK:

bash
dotnet --version

9. Database Setup

Open MySQL Workbench and connect to your local MySQL server.

Create the database:

sql
CREATE DATABASE IF NOT EXISTS shareplate_db
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;


Create a dedicated database user if one does not already exist. Set a strong password and grant that user access to shareplate_db.

Configure the application's connection string using .NET user secrets rather than committing credentials to GitHub.

From the project directory, run:

bash
dotnet user-secrets init


Then configure your connection string using your actual local MySQL credentials:

bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=shareplate_db;User=shareplate_user;Password=YOUR_PASSWORD;"


Replace YOUR_PASSWORD with your database user's password.

10. Installation and Execution
Step 1: Clone the repository
bash
git clone https://github.com/JignyasaPatil29/SharePlate-.git

Step 2: Open the project
bash
cd SharePlate-


Open the folder containing SharePlate.csproj in Visual Studio Code.

If the cloned directory has a different name, navigate into the directory that contains the project file.

Step 3: Restore dependencies
bash
dotnet restore

Step 4: Install EF Core CLI if required
bash
dotnet tool install --global dotnet-ef


If it is already installed, update it when necessary instead of installing it again.

Step 5: Apply database migrations
bash
dotnet ef database update


This applies the migrations included in the repository to the configured MySQL database.

Step 6: Build the application
bash
dotnet build

Step 7: Run the application
bash
dotnet run


Open the HTTP or HTTPS address printed in the terminal.

11. Testing

The following tests should be performed before project submission:

Test case	Expected result
Add valid donation	Record is saved
View donations	Records are displayed
Open donation details	Selected record is displayed
Edit a donation	Updated values are saved
Delete a donation	Record is removed after confirmation
Submit invalid values	Validation errors are displayed
Filter by status	Matching records are displayed
Restart application	Saved records remain in MySQL

Record the actual results after running each test. Do not report untested results as successful.

12. Results

The implemented application is designed to demonstrate persistent donation record management through ASP.NET Core MVC and MySQL.

After successful testing, screenshots can be added here to demonstrate:

Donation dashboard
Add Donation form
Donation Details page
Edit Donation page
Validation messages
Database records in MySQL Workbench
13. Limitations

The current mini-project focuses on donation record management. Depending on the implemented version, it may not include:

User authentication and role-based authorization
Separate donor, NGO, and volunteer accounts
A complete reservation and collection workflow
Automated notifications
Maps or location-based matching

These features can be considered for future development.

14. Future Enhancements
Add authentication and role-based access control.
Introduce NGO and volunteer accounts.
Implement reservation requests and pickup confirmation.
Add search and advanced filtering.
Provide notifications for approaching pickup deadlines.
Include food safety, allergen, and storage information.
Develop donation statistics and reporting dashboards.
15. Conclusion

SharePlate demonstrates how an ASP.NET Core MVC application can be used to organize surplus food donation records through a structured web interface and a persistent MySQL database.

The project applies MVC architecture, Entity Framework Core, CRUD operations, model validation, state management, and responsive UI design. It provides a foundation for a more comprehensive food redistribution platform that can help improve donation coordination and reduce avoidable food waste.

16. Project Information
Project Title: SharePlate – Food Surplus and Donation Management System
Project Type: College Mini-Project
Repository: https://github.com/JignyasaPatil29/SharePlate-
IDE: Visual Studio Code
Database: MySQL

Student Name: Add your name
Roll Number: Add your roll number
Department: Add your department
College: Add your college name
Academic Year: 2026–2027
