namespace App.Domain.API.Services
{
    using App.Infrastructure.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class RegisterIoC : IIoCRegister
    {
        public void Build(IServiceCollection container)
        {
            container.AddTransient<IGoogleBookService, GoogleBookService>();

        }
    }
}
