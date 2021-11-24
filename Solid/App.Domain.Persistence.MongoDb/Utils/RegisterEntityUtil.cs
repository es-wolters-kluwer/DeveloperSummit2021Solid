namespace App.Domain.Persistence.MongoDb.Utils
{
    using System;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;

    public static class RegisterEntityUtil
    {
        public static void Register<TInterface, TImplementation>(Action<BsonClassMap<TImplementation>> map = null) where TImplementation : class, TInterface
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(TImplementation)))
                return;
            

            BsonClassMap.RegisterClassMap<TImplementation>(x =>
            {
                x.AutoMap();
                map?.Invoke(x);
            });

            RegisterSerializer<TInterface, TImplementation>();
        }

        private static void RegisterSerializer<TInterface, TImplementation>() where TImplementation : class, TInterface
        {
            var serializer = BsonSerializer.LookupSerializer<TImplementation>();
            BsonSerializer.RegisterSerializer(new ImpliedImplementationInterfaceSerializer<TInterface, TImplementation>(serializer));
        }
    }
}
