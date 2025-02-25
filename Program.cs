using Microsoft.EntityFrameworkCore;
using PRSNetWeb.Models;

namespace PRSNetWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(opt => {
                opt.JsonSerializerOptions.ReferenceHandler =
                  System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddDbContext<PrsdbContext>(
            // lambda
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("prsdbConnectionString"))
            );

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
