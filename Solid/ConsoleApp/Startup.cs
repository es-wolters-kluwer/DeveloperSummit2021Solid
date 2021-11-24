namespace ConsoleApp
{
    using System;
    using App.Domain.Entities;
    using App.Domain.Persistence.File;
    using App.Domain.Persistence.MongoDb;
    using App.Infrastructure.IoC;
    using App.Infrastructure.Persistence.Repositories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using UglyLoader;

    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //Read config like URL base for GoogleBookService from file
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();
            
            this.Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("GoogleBooks", client =>
            {
                //The httpClient is configured with base url before created
                client.BaseAddress = new Uri(this.Configuration["GoogleServiceBaseAddress"]);
            });

            services.AddSingleton<IConfigurationRoot>(this.Configuration);
            services.AddTransient<Application>();

            //Configure at this point FileRepository as implementation for IRepository<ISearchResultEntity>. We change the implementation later
            //services.AddTransient<IRepository<ISearchResultEntity>, FileRepository>();

            //Configure at this point a mongo repository SearchResultRepository as implementation for IRepository<ISearchResultEntity>
            services.AddTransient<IRepository<ISearchResultEntity>, SearchResultRepository>();
            

            //All assemblies is loaded and execute the Build method where IIoCRegister is implemented
            UglyLoaderApiBuilder.Build()
                .LoadAssemblies<IIoCRegister>(act => act.Build(services));

            //Register all mappings for MongoDb serialization
            UglyLoaderApiBuilder.Build()
                .LoadAssemblies<IMongoMapping>(act => act.CreateMap());

            //Sets the connection string and collections for mongoDb
            IConfigurationSection persistenceSection = this.Configuration.GetSection("Persistence");
            var persistence = persistenceSection.Get<PersistenceConfig>();

            services.AddTransient<MongoConfig>(x => new MongoConfig()
            {
                ConnectionString = this.Configuration.GetConnectionString("MongoString"),
                Persistence = persistence
            });
            
        }
    }
}
