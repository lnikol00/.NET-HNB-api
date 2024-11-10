using HnbAPI.Models;
using HnbAPI.Services.ArithmeticMeanService;
using HnbAPI.Services.HnbService;

namespace HnbAPI
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

            builder.Services.AddSingleton<IHnbService, HnbService>();
            builder.Services.AddSingleton<IArithemticMeanService, ArithemticMeanService>();

            builder.Services.Configure<ConnectionApi>(builder.Configuration.GetSection("ConnectionApi"));

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
