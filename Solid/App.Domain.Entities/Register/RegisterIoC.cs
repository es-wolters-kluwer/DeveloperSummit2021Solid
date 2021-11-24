namespace App.Domain.Entities
{
    using App.Infrastructure.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class RegisterIoC : IIoCRegister
    {
        public void Build(IServiceCollection container)
        {
            container.AddTransient<ISearchResultEntity, SearchResultEntity>();

        }
    }
}
