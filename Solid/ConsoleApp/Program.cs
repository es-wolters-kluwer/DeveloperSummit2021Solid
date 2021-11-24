namespace ConsoleApp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;


    public class Program
    {
        public static async Task Main(string[] args)
        {
            //The app IoC is configured at this point
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();
            await app.Run().ConfigureAwait(false);
        }
    }
}
