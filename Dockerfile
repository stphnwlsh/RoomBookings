###################################
######### STAGE 1 - BUILD #########
###################################
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# Restore Project Dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the Application
COPY . .

# Build the Application
RUN dotnet publish -c Release  -o out --no-restore

###################################
########## STAGE 2 - RUN ##########
###################################
FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine AS run
WORKDIR /app

# Copy the Published Application
COPY --from=build /app/out/RoomBookings.dll .
COPY --from=build /app/out/RoomBookings.runtimeconfig.json .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "RoomBookings.dll"]
