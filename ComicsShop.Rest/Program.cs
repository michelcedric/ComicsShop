using ComicsShop.Rest.Database;
using ComicsShop.Rest.Endpoints;
using ComicsShop.Rest.Middlewares;
using MinimalApi.Endpoint.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddComicsService();
builder.Services.AddDbConnection();
builder.Services.AddComicsRepository();
builder.Services.AddEndpoints();

var app = builder.Build();

app.UseApiResponse();

app.MapEndpoints();

app.Run();