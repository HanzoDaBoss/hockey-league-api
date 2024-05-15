using HockeyLeague.Api.Dtos;
using Microsoft.VisualBasic;

namespace HockeyLeague.Api.Endpoints;

public static class TeamsEndpoints
{
    const string GetTeamEndpointName = "GetTeam";

    private static readonly List<TeamDto> teams = [
        new (
            1,
            "Leicester Wolves",
            2
        ),
        new (
            2,
            "Old Bags",
            1
        ),
            new (
            3,
            "Welford",
            2
        )
    ];

    public static RouteGroupBuilder MapTeamsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("teams")
                    .WithParameterValidation();

        group.MapGet("/", () => teams);

        group.MapGet("/{id}", (int id) =>
        {
            TeamDto? team = teams.Find(team => team.Id == id);

            return team is null ? Results.NotFound() : Results.Ok(team);
        }
            )
            .WithName(GetTeamEndpointName);

        group.MapPost("/", (CreateTeamDto newTeam) =>
        {

            TeamDto team = new(
                teams.Count + 1,
                newTeam.Name,
                newTeam.Division
            );
            teams.Add(team);

            return Results.CreatedAtRoute(GetTeamEndpointName, new { id = team.Id }, team);
        });

        group.MapPut("/{id}", (int id, UpdateTeamDto updatedTeam) =>
        {
            var index = teams.FindIndex(team => team.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            teams[index] = new TeamDto(
                id,
                updatedTeam.Name,
                updatedTeam.Division
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            teams.RemoveAll(team => team.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
