# Use the official .NET 9 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file from the TasksApp subfolder and restore
COPY TasksApp/*.csproj ./TasksApp/
WORKDIR /src/TasksApp
RUN dotnet restore

# Copy the rest of the source code and build
COPY TasksApp/. ./
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET 9 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "TasksApp.dll"]
