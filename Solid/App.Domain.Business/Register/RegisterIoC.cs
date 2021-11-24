namespace App.Domain.Business
{
    using App.Infrastructure.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class RegisterIoC : IIoCRegister
    {
        public void Build(IServiceCollection container)
        {
            container.AddTransient<ISearchResultEntityMapper, SearchResultEntityMapper>();
        }
    }
}
