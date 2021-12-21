FROM mcr.microsoft.com/dotnet/sdk:latest AS build-env
WORKDIR /app
EXPOSE 1234

# Copy csproj and restore as distinct layers
COPY ./pulsar/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./pulsar ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:latest
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "pulsar.dll"]