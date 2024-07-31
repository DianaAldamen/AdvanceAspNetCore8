
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Services;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Infrastructure.Repostry;

namespace ToDoApp.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(config => { config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
            // Add services to the container.
            builder.Services.AddScoped<IToDoRepositry, ToDoItemRepostry>();
            builder.Services.AddScoped<ToDoService>();
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
        }
    }
}
