Archivum Mechanicum is a sci-fi-inspired database application built as a university project. Designed in the theme of the Adeptus Mechanicus, the app serves as a repository for relics, records, and locations in a futuristic, lore-driven setting.

Features
CRUD Operations: Fully implemented Create, Read, Update, and Delete functionalities for managing:

Relics: Unique items with classifications, origins, and descriptions.
Records: Detailed inscriptions linked to relics and locations.
Locations: Planets, stations, and outposts with custodians and coordinates.
Data Seeding: Populate the database with lore-rich JSON data, including interconnected entities.

JWT Authentication: Secure user login and API access with role-based authorization.

Swagger Integration: Explore and test API endpoints interactively.

Technology Stack
Backend: ASP.NET Core 6
Database: Entity Framework Core with SQL Server
API Documentation: Swagger
Authentication: JWT (JSON Web Tokens)

Key API Endpoints
GET /api/Locations: Fetch all locations.
POST /api/Relics: Add a new relic.
GET /api/Records/{id}: Retrieve a record by ID.
POST /api/Database/populate: Populate the database with seed data.
