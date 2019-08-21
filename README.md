# JBet

[![Build status](https://ci.appveyor.com/api/projects/status/5xu73ew2on693vhe?svg=true)](https://ci.appveyor.com/project/profjordanov/sports-system)

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/2e0461ba54e148bea7bb3b5a81e76924)](https://www.codacy.com/app/profjordanov/sports-system?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=profjordanov/sports-system&amp;utm_campaign=Badge_Grade)

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
1. Domain-Driven Design in Practice a.k.a [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
2. REST with [HATEOAS](https://github.com/riskfirst/riskfirst.hateoas) by following [HAL](http://stateless.co/hal_specification.html)
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
5. Event-sourcing via [Marten](https://jasperfx.github.io/marten/)
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

![swagger-ui](https://devadventures.net/wp-content/uploads/2018/06/swagger-ui-new.png)

14. Global Model Errors Handler

![model-errors](https://devadventures.net/wp-content/uploads/2018/05/model-errors.png)

15. Global Environment-Dependent Exception Handler

![exception-development](https://devadventures.net/wp-content/uploads/2018/06/exception-development.png)

16. Thin Controllers

Examples:
```csharp
// BetsController.cs
/// <summary>
/// Logged-in users can bet for the home team.
/// </summary>
/// <param name="input">HTTP request.</param>
[HttpPost("home-team", Name = nameof(BetForHomeTeam))]
[ProducesResponseType(typeof(UserMatchBetResource), (int)HttpStatusCode.Created)]
public async Task<IActionResult> BetForHomeTeam([FromBody] MatchHomeBetInput input) =>
    (await Mediator.Send(new UserBetForHomeTeam(input, CurrentUserId))
        .MapAsync(_ => ToEmptyResourceAsync<UserMatchBetResource>()))
        .Match(resource => CreatedAtAction(nameof(BetForHomeTeam), resource), Error);
```
17. [FluentValidation](https://fluentvalidation.net/)
18. Neat folder structure
```
├───client
│   ├───public
│   │   ├───index.html
│   │   └───manifest.json
│   ├───src
│   │   ├───api
│   │   ├───components
│   │   ├───redux
│   │   └───utils
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
│       └───Jbet.Tests
```
### Test Suite
19. Arrange Act Assert Pattern
20. xUnit
21. Autofixture
22. Moq
23. Shouldly
24. FakeItEasy
25. Respawn

# Functionality
- [x] Anonymous users can register user account by email and password.
- [x] Anonymous users can login by email and password.
- [x] Logged-in users can logout.
- [x] Anonymous users can view the home page, holding the top 3 matches (having most bets) and best 3 teams (most voted).
- [x] Anonymous users can view all matches (ordered by date, with paging).
- [x] Logged-in users can view team details (information about the team and its players).
- [x] Logged-in users can vote for a team (no more than once).
- [x] Logged-in users can view match details (home team, away team, date and comments).
- [x] Logged-in users can add comments for given match.
- [x] Logged-in users can bet for the home or away team.
