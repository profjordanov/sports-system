# JBet
Web based sport system to bet for matches, played by teams.
As a whole, this project aims to implement most of the [AspNetCore-Developer-Roadmap](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)

## Data Model
### The system holds teams, players, matches, comments, users, bets and votes.
- [x] Teams have name, nick name (optional), web site (optional), date founded (optional) and a set of players.
- [x] Players have name, date of birth, height, and may be part of some team or be unemployed.
- [x] Teams play matches. Each match has home team, away team, date and time and a set of comments.
- [x] Comments have content (text), date and time and owner user (author).
- [x] Users have username, email and password (encrypted). Users hold also a set of bets and a set of comments for the matches.
- [x] Users can bet some money for the home or away team for existing match.
- [x] Users can vote for a team (give +1) ones.

## Features
1. Domain-Driven Design in Practice
2. REST with [HATEOAS](https://github.com/riskfirst/riskfirst.hateoas)
3. Command and Query Responsibility Segregation (CQRS) via [MediatR](https://github.com/jbogard/MediatR)
4. Functional style command/query handlers via robust option/maybe type [Optional](https://github.com/nlkl/Optional)

Examples:
```csharp
// LoginHandler.cs
public Task<Option<JwtView, Error>> Handle(Login command, CancellationToken cancellationToken = default) =>
    ValidateCommand(command).FlatMapAsync(cmd =>
    FindUser(command.Email).FlatMapAsync(user =>
    CheckPassword(user, command.Password).FlatMapAsync(_ =>
    GetExtraClaims(user).MapAsync(async claims =>
    GenerateJwt(user, claims)))));
```
5. Event-sourcing
6. A complete integration tests suite

Examples:
```csharp
// AuthControllerTests.cs
[Theory]
[CustomizedAutoData]
public async Task LoginShouldSetProperHttpOnlyCookie(Register register)
{
    // Arrange
    await _authHelper.Register(register);

    var loginCommand = new Login
    {
        Email = register.Email,
        Password = register.Password
    };

    // Act
    var response = await _fixture.ExecuteHttpClientAsync(client =>
        client.PostAsJsonAsync(AuthRoute("login"), loginCommand));

    // Assert
    var token = (await response
            .ShouldDeserializeTo<LoginResource>())
        .TokenString;

    response.Headers.ShouldContain(header =>
        header.Key == "Set-Cookie" &&
        header.Value.Any(x => x.Contains(AuthConstants.Cookies.AuthCookieName) && x.Contains(token)));
}
```
7. Real-time communications through SignalR
8. AutoMapper
9. EntityFramework Core with PostgreSQL Server and ASP.NET Identity
10. JWT authentication/authorization
11. File logging with Serilog
12. Stylecop
13. Swagger UI + Fully Documented Controllers
14. Global Model Errors Handler
15. Global Environment-Dependent Exception Handler
16. Thin Controllers
17. [FluentValidation](https://fluentvalidation.net/)
18. Neat folder structure
```
├───server
│   ├───configuration
│   │   ├───analyzers.ruleset
│   │   └───stylecop.json
│   ├───src
│   │   ├───Jbet.Api
│   │   ├───Jbet.Business
│   │   ├───Jbet.Core
│   │   ├───Jbet.Domain
│   │   └───Jbet.Persistence
│   └───tests
        └───Jbet.Tests
```
