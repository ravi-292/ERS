using ERS.Services.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors();
//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<DataContext>(opt => { opt.UseInMemoryDatabase("BOOKS"); });
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
//{
//    var context = serviceProvider.GetRequiredService<DataContext>();
//    DataGenerator.SeedDefaultData(context);
//}


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseCors(options =>
//    options.WithOrigins("https://localhost:3000")
//    .WithOrigins("http://localhost:3000")
//        .AllowAnyHeader()
//        .AllowAnyMethod());

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


namespace ERS.Services
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    DataGenerator.SeedDefaultData(context);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();
                   });
            return host;
        }
    }
}