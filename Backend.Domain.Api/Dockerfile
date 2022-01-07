FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app 

COPY *.sln .
COPY Backend.Domain/*.csproj ./Backend.Domain/
COPY Backend.Domain.Api/*.csproj ./Backend.Domain.Api/
COPY Backend.Domain.Infra/*.csproj ./Backend.Domain.Infra/
COPY Backend.Domain.Shared/*.csproj ./Backend.Domain.Shared/
COPY Backend.Domain.Tests/*.csproj ./Backend.Domain.Tests/ 

RUN dotnet restore 

COPY Backend.Domain/. ./Backend.Domain/
COPY Backend.Domain.Api/. ./Backend.Domain.Api/
COPY Backend.Domain.Infra/. ./Backend.Domain.Infra/
COPY Backend.Domain.Shared/. ./Backend.Domain.Shared/
#
WORKDIR /app/Backend.Domain.Api
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app 
#
COPY --from=build-env /app/Backend.Domain.Api/out ./
ENTRYPOINT ["dotnet", "Backend.Domain.Api.dll"]