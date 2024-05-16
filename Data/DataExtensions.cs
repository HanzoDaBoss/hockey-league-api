using Microsoft.EntityFrameworkCore;

namespace HockeyLeague.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HockeyLeagueContext>();
        dbContext.Database.Migrate();
    }
}
