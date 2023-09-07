using Microsoft.EntityFrameworkCore;
using ObjectiveTestExercise.Context;
using ObjectiveTestExercise.Services;
using ObjectiveTestExercise.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Строка подключения не найдена");
builder.Services.AddDbContext<ObjectiveContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<ISubscribeService, SubscribeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
