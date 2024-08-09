
# Lodgify - Vacation Rental Booking System

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![.NET Version](https://img.shields.io/badge/.NET-2.2-blue)
![License](https://img.shields.io/badge/license-MIT-blue)

This project is part of a technical test for a backend C# developer role at Lodgify. It involves extending an existing API that manages vacation rental bookings, ensuring accurate rental availability by preventing overbookings and implementing additional features related to preparation time between bookings.

## Project Overview

### API Endpoints

1. **RentalsController**
   - `POST api/v1/rentals` - Creates a new rental with a specified number of units and preparation time in days.
   - `GET api/v1/rentals/{id}` - Retrieves information about a specific rental by ID.
   - **NEW:** `PUT api/v1/rentals/{id}` - Updates an existing rental's number of units and preparation time. Validates against overbooking.

2. **BookingsController**
   - `POST api/v1/bookings` - Creates a new booking for an existing rental.
   - `GET api/v1/bookings/{id}` - Retrieves information about a specific booking by ID.

3. **CalendarController**
   - `GET api/v1/calendar` - Retrieves booking and preparation time information for a specified rental, including occupied unit numbers.

### New Features

- **Preparation Time**: Added the ability to specify a preparation time in days for each rental. This feature ensures that after a booking ends, the rental unit remains unavailable for the specified preparation time to accommodate cleaning or other preparation needs.
- **Unit Occupancy Tracking**: Extended the calendar endpoint to include information about which specific units are booked or in preparation, preventing overbooking and ensuring accurate rental availability.

### Code Structure

- The project is implemented using C# and .NET Core 2.2.
- The business logic is contained within the controllers, maintaining consistency with the original project structure provided by Lodgify.
- Unit tests have been implemented to ensure the correctness of the new features.

## Getting Started

### Prerequisites

- [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)

### Running the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/lodgify/public-money-recruitment-be-test.git
   ```
2. Navigate to the project directory:
   ```bash
   cd public-money-recruitment-be-test
   ```
3. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```
4. Access the Swagger documentation at:
   ```bash
   http://localhost:5000/swagger
   ```

## Testing

Unit tests have been provided to verify the functionality of the API endpoints, including the new features. To run the tests:
```bash
dotnet test
```

## License

This project is licensed under the MIT License.
