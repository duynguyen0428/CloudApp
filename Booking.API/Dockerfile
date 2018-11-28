FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

# FROM microsoft/dotnet:2.1-sdk AS build
# WORKDIR /src
# COPY *.sln ./
# COPY Booking.API/Booking.API.csproj Booking.API/
# RUN dotnet restore
# COPY . .
# WORKDIR /src/Booking.API
# RUN dotnet build -c Release -o /app

# FROM build AS publish
# RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY  ./bin/Release/netcoreapp2.1/publish .
ENTRYPOINT ["dotnet", "Booking.API.dll"]
