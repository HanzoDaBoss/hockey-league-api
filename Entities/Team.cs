namespace HockeyLeague.Api.Entities;

public class Team
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int DivisionId { get; set; }

    public Division? Division { get; set; }
}
