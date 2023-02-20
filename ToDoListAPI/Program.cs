using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Database;
using ToDoListAPI.Repositories;

namespace ToDoListAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ToDoContext>(o =>
            {
                var cs = builder.Configuration.GetConnectionString("SqLite");
                o.UseSqlite(cs);
            });
            builder.Services.AddTransient<ToDoListRepository>();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowAnyOrigin();
                });
            });
           
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ToDoContext>();
                db.Database.OpenConnection();
                db.Database.Migrate();
                db.Database.CloseConnection();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}