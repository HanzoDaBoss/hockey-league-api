using HockeyLeague.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapTeamsEndpoints();

app.Run();
