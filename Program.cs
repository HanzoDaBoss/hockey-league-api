using HockeyLeague.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.MapGet("teams/{id}", (int id) => teams.Find(team => team.Id == id));

app.Run();
