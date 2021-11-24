namespace App.Infrastructure.Serialization
{
    using System;

    /// <summary>
    /// Its a wrapper for serialization
    /// </summary>
    public interface IAppSerializer : IDisposable
    {
        T Deserialize<T>(string jsonText) where T : class;
        string Serialize(object source);
    }
}
