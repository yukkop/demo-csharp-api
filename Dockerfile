# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory.
WORKDIR /app

# Make port 80 available to the world outside this container.
EXPOSE 80

# Run the specified command within the container.
ENTRYPOINT ["dotnet", "WebApi.dll"]