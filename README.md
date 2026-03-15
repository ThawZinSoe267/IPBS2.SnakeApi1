# Snake API Project Overview

This is an ASP.NET Core Web API project that provides information about various types of snakes. The project is structured into two main components: the API layer and the Database layer.

## Architecture

*   **`IPBS2.SnakeApi1` (Web API)**: The main ASP.NET Core Web API project that exposes RESTful endpoints for clients to consume.
*   **`IPBS2.SnakeApi.Database` (Class Library)**: Contains the Entity Framework Core database context (`AppDbContext`) and the entity models.

## Database Model

The API relies on a SQL Server database. The core entity is **`Snake`**, which contains the following properties:

*   `Id`: Unique identifier for the snake.
*   `Mmname`: The name of the snake in Myanmar (Burmese).
*   `EngName`: The English name of the snake.
*   `Detail`: Detailed description or information about the snake.
*   `IsPoison`: Indicates if the snake is venomous/poisonous.
*   `IsDanger`: Indicates if the snake is dangerous.

## API Endpoints

The API exposes the following endpoints through the `SnakeController`:

### 1. Get All Snakes (Paginated)
*   **Endpoint:** `GET /api/Snake`
*   **Parameters:**
    *   `page` (optional, default: 1): The page number.
    *   `pageSize` (optional, default: 10): The number of items per page.
*   **Description:** Returns a paginated list of all snakes in the database, along with total count and pagination metadata.

### 2. Get Snake Details
*   **Endpoint:** `GET /api/Snake/{id}`
*   **Parameters:**
    *   `id` (required): The unique ID of the snake.
*   **Description:** Returns the complete details of a specific snake by its ID. Returns a 404 Not Found if the snake doesn't exist.

### 3. Search Snakes
*   **Endpoint:** `GET /api/Snake/search`
*   **Parameters:**
    *   `keyword` (required): The search term.
    *   `page` (optional, default: 1): The page number.
    *   `pageSize` (optional, default: 10): The number of items per page.
*   **Description:** Searches for snakes where the `keyword` matches either the English name (`EngName`) or the Myanmar name (`Mmname`). The results are paginated.

## Technology Stack
*   **Framework:** ASP.NET Core Web API
*   **ORM:** Entity Framework Core
*   **Database:** SQL Server
*   **Documentation:** Swagger / OpenAPI
