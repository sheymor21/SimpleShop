FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /Project
COPY SimpleShop/*.csproj .
RUN dotnet restore
COPY SimpleShop/ .

WORKDIR /Project
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runetime
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8080

COPY --from=build ./Project/out .
ENTRYPOINT ["dotnet", "SimpleShop.dll"]