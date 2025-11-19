Newton Video Games Catalogue
A full-stack catalog application built with .NET 8 Web API and Angular 17.

Newton Video Games Catalogue is a full-stack application designed to manage and browse video game data.
It contains:
  .NET 8 Backend API
  Angular Frontend
  Unit Tests with xUnit
  Entity Framework Core
  REST endpoints
  CRUD operations

Technology Stack
----------------------------
  Backend (.NET 8)
    C#  ASP.NET Core Web API
    Entity Framework Core
    SQL Server (In-memory data)
    xUnit tests
    
  Frontend (Angular 17)
    Angular CLI
    TypeScript
    HttpClient for API integration
    
Project Structure
---------------------------------------------------------
Newton.VideoGames.Catalogue/
├── backend/
│   ├── Newton.VideoGames.Catalogue.sln
│   ├── Newton.VideoGames.Catalogue/
│   └── Newton.VideoGames.Catalogue.Tests/
│
├── frontend/
│   ├── angular.json
│   ├── package.json
│   ├── tsconfig.json
│   └── src/
│
├── .gitignore
├── README.md
└── LICENSE   (optional)

Backend Setup
----------------------------
Run API
		cd backend/Newton.VideoGames.Catalogue
		dotnet run

API runs at:
		https://localhost:7038  
		http://localhost:5089

Running Tests
		cd backend/Newton.VideoGames.Catalogue.Tests
		dotnet test

Frontend Setup
------------------------------------
 Install dependencies
		cd frontend
		npm install

 Frontend opens at:
		http://localhost:4200

API Endpoints
------------------------------
   Method			Endpoint				    Description
    	GET				/api/vgames		    Get all video games
    	GET				/api/vgames/{id}	Get game by ID
    	POST			/api/vgames		    Add a new game
    	PUT				/api/vgames/{id}	Update a game
   	DELETE			/api/vgames/{id}	Delete a game

License
	MIT License.

