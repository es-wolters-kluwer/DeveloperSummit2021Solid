namespace App.Infrastructure.Serialization
{
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Resolve the correct type for interfaces on serialization
    /// </summary>
    public interface IAppContractResolver : IContractResolver
    {
    }

}
