# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file from the TasksApp subfolder and restore
COPY TasksApp/*.csproj ./TasksApp/
WORKDIR /src/TasksApp
RUN dotnet restore

# Copy the rest of the source code and build
COPY TasksApp/. ./
RUN dotnet publish -c Release -o /app/publish

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port Render expects
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Set the entry point for the container
ENTRYPOINT ["dotnet", "TasksApp.dll"]