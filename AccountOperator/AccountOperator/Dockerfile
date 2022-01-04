FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AccountOperator/AccountOperator.csproj", "AccountOperator/"]
RUN dotnet restore "AccountOperator/AccountOperator.csproj"
COPY . .
WORKDIR "/src/AccountOperator"
RUN dotnet build "AccountOperator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountOperator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountOperator.dll"]
