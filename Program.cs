using HockeyLeague.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetTeamEndpointName = "GetTeam";

List<TeamDto> teams = [
    new (
        1,
        "Leicester Wolves",
        2
    ),
    new (
        2,
        "Old Bags",
        1
    )
];

app.MapGet("teams", () => teams);

app.MapGet("teams/{id}", (int id) => teams.Find(team => team.Id == id))
    .WithName(GetTeamEndpointName);

app.MapPost("teams", (CreateTeamDto newTeam) =>
{
    TeamDto team = new(
        teams.Count + 1,
        newTeam.Name,
        newTeam.Division
    );
    teams.Add(team);

    return Results.CreatedAtRoute(GetTeamEndpointName, new { id = team.Id }, team);
});

app.Run();
