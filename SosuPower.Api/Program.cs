
using Microsoft.EntityFrameworkCore;

using SosuPower.DataAccess;

namespace SosuPower.Api
{
    public class Program
    {
        private const string DbConnection = "SosuPowerConnection";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SosuPowerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SosuPowerConnection")
                )
            );

            //builder.Services.AddScoped<DbContext, Repository<Entities.Task>>();
            builder.Services.AddScoped<IRepository<Entities.Task>, Repository<Entities.Task>>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
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
