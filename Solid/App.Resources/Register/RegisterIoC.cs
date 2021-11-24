namespace App.Domain.Resources
{
    using App.Infrastructure.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class RegisterIoC : IIoCRegister
    {
        public void Build(IServiceCollection container)
        {
            container.AddTransient<IApiItemResource, ApiItemResource>();
            container.AddTransient<IApiResponseResource, ApiResponseResource>();
            container.AddTransient<IApiSearchInfo, ApiSearchInfo>();
            container.AddTransient<IApiVolumeInfoResource, ApiVolumeInfoResource>();
        }
    }
}
