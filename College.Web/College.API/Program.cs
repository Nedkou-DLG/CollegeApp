using College.API.Application.Interfaces;
using College.API.Application.Services;
using College.API.Configurations;
using College.Domain.Interfaces.Repositories;
using College.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace College.API;

public class Program
{
    public static void Main(string[] args)
    {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IStudentService, StudentService>();
       builder.Services.AddAutoMapper(
           typeof(StudentProfile));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<CollegeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeDBContext")));

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
    }
}

