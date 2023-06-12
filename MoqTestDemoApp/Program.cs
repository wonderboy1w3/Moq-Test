using Microsoft.EntityFrameworkCore;
using MoqTestDemoApp.Data;
using MoqTestDemoApp.Interfaces;
using MoqTestDemoApp.IRepositories;
using MoqTestDemoApp.Models;
using MoqTestDemoApp.Repositories;
using MoqTestDemoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.
        GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
