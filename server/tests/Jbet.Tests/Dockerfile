FROM endeveit/docker-jq AS config
WORKDIR /src
COPY . .
WORKDIR /src/tests/Jbet.Tests
RUN jq '.ConnectionStrings.DefaultConnection = "Server=relationaldb;Port=5432;Database=jbet-relational;User Id=postgres;Password=postgres;"' appsettings.json > tmp.$$.json && mv tmp.$$.json appsettings.json
RUN jq '.EventStore.ConnectionString = "Server=eventstore;Port=5432;Database=jbet-event-store;User Id=postgres;Password=postgres;"' appsettings.json > tmp.$$.json && mv tmp.$$.json appsettings.json
RUN cat appsettings.json

FROM microsoft/dotnet:2.2-sdk AS build

WORKDIR /src

COPY --from=config /src .

RUN ls

WORKDIR /src/tests/Jbet.Tests

RUN ls

RUN dotnet test Jbet.Tests.csproj