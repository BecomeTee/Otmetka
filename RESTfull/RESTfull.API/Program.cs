using Microsoft.EntityFrameworkCore;
using RESTfull.Infrastructure.Interfaces;
using RESTfull.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Мое
builder.Services.AddScoped<InterfaceAttend, AttendRepository>();
builder.Services.AddScoped<InterfaceStudent, StudentRepository>();
builder.Services.AddScoped<InterfaceClass, ClassRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//НАписали мы
builder.Services.AddDbContext<RESTfull.Infrastructure.Data.Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Enable CORS 
app.UseCors(options =>
{
    options.AllowAnyOrigin() // Разрешить доступ со всех источников 
           .AllowAnyMethod() // Разрешить любые HTTP методы 
           .AllowAnyHeader(); // Разрешить любые заголовки 
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();
/////
//app.UseAuthentication();
/////
app.UseAuthorization();

//////
//app.UseRouting();
//////
app.MapControllers();

app.Run();
