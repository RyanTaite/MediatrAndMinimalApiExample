using System.Diagnostics;
using Example.Api;
using Example.Api.Endpoints;
using Example.Persistence.Members;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection();

// Add in-memory database
const string inMemoryDatabaseName = "MediatRExampleInMemoryDatabase";
builder.Services.AddDbContext<MembersDbContext>(optionsBuilder =>
{
    optionsBuilder.UseInMemoryDatabase(inMemoryDatabaseName);
    
    optionsBuilder.EnableSensitiveDataLogging();
    optionsBuilder.EnableDetailedErrors();
    optionsBuilder.LogTo(message => Debug.WriteLine(message));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map endpoints
app.MapAttendanceEndpoints();
app.MapMembersEndpoints();

app.Run();