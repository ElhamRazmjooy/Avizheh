using Microsoft.EntityFrameworkCore;
using NotificationSystem.Application.Notifications.Handlers;
using NotificationSystem.Domain.Repositories;
using NotificationSystem.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NotificationDbContext>(x => x.UseSqlServer(builder.Configuration
    .GetConnectionString("NotificationConnection")));
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<CreateNotificationHandler>();

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
