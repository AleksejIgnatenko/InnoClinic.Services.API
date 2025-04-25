using InnoClinic.Services.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureBuilder();

var app = await builder
    .Build()
    .ConfigureApplicationAsync();

app.Run();