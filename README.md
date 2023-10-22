# Vehicle Management System

This is a simple Vehicle Management System that allows you to manage vehicles with various details, including registration number, model name, number of seats, and the option to have a single color or multiple colors. The system is built using the MVC (Model-View-Controller) pattern with a three-tier architecture. Below are the details of the system:

## Entity-Relationship Diagram

The system is designed based on the following entity-relationship diagram:

- **Vehicle**
  - Registration Number (unique identifier)
  - Model Name (not nullable)
  - Number of Seats (less than 1000)
  - Is Single Color (boolean, indicating if the vehicle has a single color)
  - Colors (associated with the vehicle)

- **Color**
  - Color ID (unique identifier)
  - Color Name (not nullable)
  - Vehicle Registration Number (foreign key referencing Vehicle)

## Database Schema

The system uses a relational database with two tables:

1. **Vehicle**:
   - RegNo (Primary Key)
   - ModelName
   - NumSeats
   - IsSingleColor

2. **Color**:
   - ColorID (Primary Key)
   - ColorName
   - VehicleRegNo (Foreign Key referencing Vehicle)

## Features

- **Add Vehicle**: Add a new vehicle with the following details:
  - Registration Number (unique)
  - Model Name (not nullable)
  - Number of Seats (less than 1000)
  - Single Color or Multiple Colors

- **Retrieve Vehicles**: Retrieve all vehicles in ascending order based on their model names. Displayed information includes registration number, model name, number of seats and colors.

## Validation

The system includes validation to ensure data integrity and accuracy:
- Registration number must be unique.
- Model name is a required field.
- Number of seats should be less than 1000.

## Code Structure

The system is organized according to the three-tier architecture with the MVC pattern:

- **Model**: Represents the data model, including entities like Vehicle and Color.
- **View**: Contains the presentation layer, including Razor views for displaying and collecting data.
- **Controller**: Manages the application's flow, handles user input, and interacts with the model and view.

## Database Connectivity

A connection class is used to access the database. Entity Framework Core is employed for database operations. It includes code for database context, migrations, and data access.
