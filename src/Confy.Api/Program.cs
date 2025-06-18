using Confy.Application;
using Confy.Domain;
using Confy.Infrastructure;
namespace Confy.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.BuildInfrastructure();

            builder.Services
                .AddApplication()
                .AddInfrastructue(builder.Configuration)
                .AddDomain();

            var app = builder.Build();
            app.UseInfrastructure();


            app.Run();
        }
    }
}
