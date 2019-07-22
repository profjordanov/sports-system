# JBet
Web based sport system to bet for matches, played by teams.

## Data Model
### The system holds teams, players, matches, comments, users, bets and votes.
- [x] Teams have name, nick name (optional), web site (optional), date founded (optional) and a set of players.
- [x] Players have name, date of birth, height, and may be part of some team or be unemployed.
- [x] Teams play matches. Each match has home team, away team, date and time and a set of comments.
- [x] Comments have content (text), date and time and owner user (author).
- [x] Users have username, email and password (encrypted). Users hold also a set of bets and a set of comments for the matches.
- [x] Users can bet some money for the home or away team for existing match.
- [x] Users can vote for a team (give +1) ones.
