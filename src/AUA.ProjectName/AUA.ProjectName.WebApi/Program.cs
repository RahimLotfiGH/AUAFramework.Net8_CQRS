using AUA.ProjectName.WebApi.AppConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigSerilog();

builder.Services.Configuration();

var app = builder.Build();

app.Configuration();

app.Run();
