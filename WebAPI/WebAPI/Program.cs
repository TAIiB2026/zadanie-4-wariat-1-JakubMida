using Interfaces;
using Services;
using WebAPI.Models;
using WebAPI.Services;


namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var produkty = new List<Product>
            {
                new Product {Id= 1, Nazwa="Truskawki", Cena= 30, DataWaznosci = new DateOnly(2026,04,06)},
                new Product {Id= 1, Nazwa="Jablka", Cena= 25, DataWaznosci = new DateOnly(2026,09,12)}
            };

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var polityka = "Polityka";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(polityka, policy =>
                {
                    policy.WithOrigins("http://localhost:4113")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddSingleton(produkty);
            builder.Services.AddSingleton<GetDataInterface<Product>, ProductService>();
            builder.Services.AddSingleton<FormSubmitInterface<Product>, FormService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(polityka);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
