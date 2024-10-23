
using Microsoft.EntityFrameworkCore;
using Task_22_10_2024.Context;
using Task_22_10_2024.Repos;
using Task_22_10_2024.Services;

namespace Task_22_10_2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // insrimento context ___-_____---____--___-______----
             // inserisci il context nel program 
             // configura context 
            builder.Services.AddDbContext<taskContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest")));



            // inietto nel program le repo 
            builder.Services.AddScoped<UtenteREPO>();

            builder.Services.AddScoped<IscrizioneREPO>();

            builder.Services.AddScoped<CorsoREPO>();


            builder.Services.AddScoped<UtenteServices>();
            builder.Services.AddScoped<IscrizioneServices>();
            builder.Services.AddScoped<CorsoServices>();
            //

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

            app.Run();
        }
    }
}
