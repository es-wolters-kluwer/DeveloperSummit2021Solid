namespace App.Infrastructure.Serialization
{
    using System;

    /// <summary>
    /// For evaluate if a implementation is registered in the IoC
    /// </summary>
    public interface IIoCMetadata
    {
        bool IsRegistered(Type t);
        Type GetType(Type t);
    }
}
