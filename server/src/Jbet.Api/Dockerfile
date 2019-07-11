FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 3646
EXPOSE 44343

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Jbet.Api/Jbet.Api.csproj src/Jbet.Api/
RUN dotnet restore src/Jbet.Api/Jbet.Api.csproj
COPY . .
WORKDIR /src/src/Jbet.Api
RUN dotnet build Jbet.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Jbet.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Jbet.Api.dll"]
