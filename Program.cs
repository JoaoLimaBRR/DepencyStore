using DependencyStore;
using DependencyStore.DataProviders.Repositories;
using DependencyStore.DataProviders.Repositories.Contracts;
using DependencyStore.DataProviders.Services;
using DependencyStore.DataProviders.Services.Contracts;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DependencyExtension.AddRepositories(builder.Services);

DependencyExtension.AddServices(builder.Services);

var app = builder.Build();

app.MapControllers();

app.Run();