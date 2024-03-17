using Appointments.DataAccess;
using Appointments.Services;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)) // Replace with your actual MySQL server version
    );
});
builder.Services.AddScoped<ICustomerAppointmentService, CustomerAppointmentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

var app = builder.Build();

// Apply migrations on application startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        Console.WriteLine("Database migrations applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while applying database migrations.");
        Console.WriteLine(ex.Message);
    }
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
