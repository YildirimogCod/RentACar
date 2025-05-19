using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Services.Car;
using RentCar.Application.Services.RentedCar;
using RentCar.Application.Services.User;
using RentCar.Persistence.Context;
using RentCar.Persistence.Repositories.CarRepositories;
using RentCar.Persistence.Repositories.RentedCarRepositories;
using RentCar.Persistence.Repositories.UserRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RentCarDbContext>();
builder.Services.AddScoped<ICarServices, CarServices>();
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentedCarRepository, RentedCarRepository>();
builder.Services.AddScoped<IRentedCarService, RentedCarService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
