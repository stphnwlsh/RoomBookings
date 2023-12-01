# Project Name

## Description

A sample project to calculate the number of rooms required to handle a collection of bookings.  Given that each booking is for a single room only and has a start and end time associated with each booking.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)

## Installation

### Dependencies

Building and running the application requires Git to retrieve and .NET 8 to build and run the application. You can choose to use Docker to avoid installing the .NET SDK on your machine or to run it natively via the .NET 8 SDK.

- Download [Git](https://git-scm.com/downloads) here
- Download [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) here

or 

- Download [Git](https://git-scm.com/downloads) here
- Download [Docker Desktop](https://www.docker.com/products/docker-desktop/) here

### Docker Instructions

```bash
# Clone the repository
git clone https://github.com/stphnwlsh/RoomBookings.git

# Navigate to the project directory
cd RoomBookings

# Build the project
docker build . -t roombookings
```

### .NET Instructions

```bash
# Clone the repository
git clone https://github.com/stphnwlsh/RoomBookings.git

# Navigate to the project directory
cd RoomBookings

# Build the project
dotnet build
```

## Usage

### Docker Instructions

```bash
# Run the application with default settings
docker run roombookings
```

### .NET Instructions

```bash
# Run the application with default settings
dotnet run
```
