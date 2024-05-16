using HockeyLeague.Api.Data;
using HockeyLeague.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("HockeyLeague");
builder.Services.AddSqlite<HockeyLeagueContext>(connString);

var app = builder.Build();

app.MapTeamsEndpoints();

app.MigrateDb();

app.Run();
