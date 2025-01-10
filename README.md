
# EShop Microservices

This project is a sample microservices-based e-commerce application designed to demonstrate various architectural patterns, technologies, and best practices. It consists of multiple microservices that work together to provide e-commerce functionality, including product catalog management, basket management, ordering, and discounting.

## Project Structure

The solution is organized into several key components:

### 1. **ApiGateways**
   This folder contains the API Gateway implementations, which act as entry points for clients. The API Gateway handles request routing, composition, and protocol translation.

### 2. **BuildingBlocks**
   This folder contains shared components and reusable modules that are used across different microservices. Notable submodules include:
   - **BuildingBlocks.Messaging**: Provides messaging abstractions and implementations for inter-service communication using a message broker.
   - **BuildingBlocks**: Contains core utilities, domain abstractions, and common infrastructure code.

### 3. **Services**
   This folder contains individual microservices, each responsible for a specific domain within the e-commerce application:

   - **Basket**: Handles shopping cart operations such as adding and removing items.
   - **Catalog**: Manages product information, including listing and retrieval.
   - **Discount**: Manages discount rules and coupon codes.
   - **Ordering**: Handles order creation, processing, and management.

### 3. **WebApps**
   This folder contains web applications that provide front-end functionality for the e-commerce platform.

### 4. **Docker Configuration**
   The project includes multiple Docker configuration files for running the application in a containerized environment:
   - **docker-compose.yml**: Main Docker Compose file for orchestrating services.
   - **docker-compose.override.yml**: Override configuration for local development.

## Supporting Services

The project relies on several supporting services to provide essential infrastructure for the microservices:

- **PostgreSQL**: Used as the primary database for the Catalog and Basket services.
- **Redis**: Serves as a distributed cache for the Basket service to enhance performance and scalability.
- **RabbitMQ**: Acts as the message broker, enabling asynchronous communication between microservices.
- **SQL Server**: Used as the database for the Ordering service.
- **SQLite**: Lightweight database.
- **YARP API Gateway**: A reverse proxy that acts as a single entry point for the microservices, handling routing and load balancing.

## Key Technologies and Patterns

The project leverages a range of modern technologies and architectural patterns:

### Core
Technologies, frameworks, and patterns that are essential to the project and directly impact the core architecture and functionality:

- **C# and .NET Core**: Core language and framework for all services.
- **Docker**: Containerization of services for easy deployment and scaling.
- **RabbitMQ**: Message broker for asynchronous communication between microservices.
- **gRPC**: High-performance communication between microservices.
- **MassTransit**: Library for message-based communication in distributed systems.
- **Marten**: Document database and event store for persisting data.
- **Entity Framework Core**: ORM for data access in services requiring relational data.
- **MediatR**: Implements the mediator pattern to reduce coupling between components.

### Architectural Patterns
- **Microservices Architecture**: Each service is independently deployable and handles a specific business capability.
- **Domain-Driven Design (DDD)**: The project is designed around core domain concepts and aggregates.
- **CQRS**: Command Query Responsibility Segregation is used to separate read and write operations.
- **Event-Driven Communication**: Services communicate via events to achieve eventual consistency.
- **API Gateway Pattern**: Provides a single entry point for clients and handles routing to the appropriate microservice.

### External Enhancements
Libraries and frameworks used to enhance functionality, improve developer experience, or handle specific concerns:

- **HealthChecks**: For monitoring service health and dependencies.
- **Custom Exception Handling System**: Centralized error handling for consistent responses.
- **FluentValidation**: Strongly-typed validation rules.
- **Mapster**: Fast object mapping for DTO and entity transformations.
- **FeatureManagement**: Feature flag support for managing feature rollouts.
- **Scrutor**: Assembly scanning and DI registration.
- **Carter**: Minimal API framework for lightweight HTTP services.
- **Postman**: Manual API testing with provided collections.

## How to Run the Project

### Prerequisites
- **Docker** and **Docker Compose** installed on your machine.
- .NET Core SDK (if running locally without Docker).

### Running with Docker Compose
1. Clone the repository:
   ```bash
   git clone https://github.com/eugeneonufran/EShop-MicroServices.git
   cd EShop-MicroServices-main/src
   ```
2. Build and start the services using Docker Compose:
   ```bash
   docker-compose up --build
   ```
3. The services will be available at the following URLs (assuming default configuration):
   - **API Gateway**: http://localhost:5000
   - **Basket Service**: http://localhost:5001
   - **Catalog Service**: http://localhost:5002
   - **Ordering Service**: http://localhost:5003

4. The databases will be seeded automatically during startup, so you don't need to perform any manual data setup.

5. Download and import the provided Postman collection for API testing from [Postman Collection](docs/EShopMicroservices.postman_collection.json).

### Running Locally without Docker
1. Open the solution `eshop-microservices.sln` in Visual Studio or your preferred IDE.
2. Set multiple startup projects for the microservices you want to run.
3. Build and run the solution.

## What This Project Demonstrates

### Core Skills
- **Microservices Design**: Independent services with clear boundaries.
- **Asynchronous Messaging**: Using RabbitMQ and MassTransit for reliable communication.
- **Event-Driven Architecture**: Ensuring loose coupling and eventual consistency.
- **Containerization**: Dockerizing services for ease of deployment.
- **Database Patterns**: Using Marten for document storage and EF Core for relational data.
- **Clean Architecture**: Layered architecture ensuring separation of concerns.

### Advanced Concepts
- **API Gateway**: Centralized routing and security for microservices.
- **CQRS with MediatR**: Clear segregation of read and write responsibilities.
- **Domain-Driven Design**: Modeling the domain with rich entities and value objects.
- **Distributed Systems**: Handling cross-service communication and fault tolerance.

## License
This project is licensed under the MIT License. See the `LICENSE` file for more details.

---

If you have any questions or suggestions, feel free to reach out via GitHub Issues.
