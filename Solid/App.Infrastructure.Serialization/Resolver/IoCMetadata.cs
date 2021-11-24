namespace App.Infrastructure.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    public class IoCMetadata : IIoCMetadata
    {
        private readonly IDictionary<Type, Type> register = new Dictionary<Type, Type>();

        public IoCMetadata(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            foreach (var s in services)
            {
                register[s.ServiceType] = s.ImplementationType;
            }
        }
        public bool IsRegistered(Type t)
        {
            return register.ContainsKey(t);
        }

        public Type GetType(Type t)
        {
            return register[t];
        }
    }
}
