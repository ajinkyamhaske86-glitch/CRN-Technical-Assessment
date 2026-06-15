# CRN Technical Assessment

## Overview

RESTful API built using .NET 8 and ASP.NET Core Web API for Product and Item management.

## Technology Stack

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger
* FluentValidation
* Serilog
* Docker
* xUnit

## Features

* Product CRUD Operations
* Item CRUD Operations
* JWT Authentication
* Swagger Authorization
* Global Exception Middleware
* Logging using Serilog
* Validation using FluentValidation

## Database

Tables:

* Product
* Item

Relationship:

* One Product can have multiple Items

## Authentication

JWT Bearer Token Authentication implemented using ASP.NET Core Authentication.

## API Endpoints

### Product

* GET /api/Products
* GET /api/Products/{id}
* POST /api/Products
* PUT /api/Products/{id}
* DELETE /api/Products/{id}

### Item

* GET /api/Items
* GET /api/Items/{id}
* POST /api/Items
* PUT /api/Items/{id}
* DELETE /api/Items/{id}

### Auth

* POST /api/Auth/login

## Testing

Implemented xUnit tests.

## Logging

Implemented Serilog file logging.

## Docker

Dockerfile and docker-compose.yml included.
