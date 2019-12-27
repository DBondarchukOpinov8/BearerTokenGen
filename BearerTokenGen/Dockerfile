FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
Expose 5001
Expose 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY "BearerTokenGen.csproj" .
RUN dotnet restore "BearerTokenGen.csproj"
COPY . .
#WORKDIR "/src/BearerTokenGen"
RUN dotnet build "BearerTokenGen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BearerTokenGen.csproj" -c Release -o /app/publish

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD dotnet BearerTokenGen.dll