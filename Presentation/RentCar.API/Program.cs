using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Services.Auth;
using RentCar.Application.Services.Car;
using RentCar.Application.Services.RentedCar;
using RentCar.Application.Services.User;
using RentCar.Persistence.Context;
using RentCar.Persistence.Repositories.CarRepositories;
using RentCar.Persistence.Repositories.RentedCarRepositories;
using RentCar.Persistence.Repositories.UserRepositories;
using RentCar.Persistence.Services.AuthServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("User", policy => policy.RequireRole("user"));
});

// Add services to the container.
builder.Services.AddDbContext<RentCarDbContext>();
builder.Services.AddScoped<ICarServices, CarServices>();
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentedCarRepository, RentedCarRepository>();
builder.Services.AddScoped<IRentedCarService, RentedCarService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
