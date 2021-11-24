namespace App.Infrastructure.IoC
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Interface used for load and configured all the assemblies where it's present
    /// </summary>
    public interface IIoCRegister
    {
        void Build(IServiceCollection container);
    }
}
