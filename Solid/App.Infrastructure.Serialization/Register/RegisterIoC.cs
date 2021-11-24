namespace App.Infrastructure.Serialization
{
    using App.Infrastructure.IoC;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public class RegisterIoC : IIoCRegister
    {
        public void Build(IServiceCollection container)
        {
            container.AddTransient<IAppContractResolver, AppContractResolver>();
            container.TryAddSingleton<IIoCMetadata>(s => new IoCMetadata(container));
            container.AddTransient<IAppSerializer, AppSerializer>();
        }
    }
}
