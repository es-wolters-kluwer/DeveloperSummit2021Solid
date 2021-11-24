namespace App.Infrastructure.Serialization
{
    using System;
    using Newtonsoft.Json.Serialization;

    public class AppContractResolver : CamelCasePropertyNamesContractResolver, IAppContractResolver
    {
        private readonly IIoCMetadata metadata;
        private readonly IServiceProvider serviceProvider;

        public AppContractResolver(IIoCMetadata serviceCollection, IServiceProvider serviceProvider)
        {
            this.metadata = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {

            if (this.metadata.IsRegistered(objectType))
            {
                JsonObjectContract contract = ResolveContact(objectType);
                contract.DefaultCreator = () => this.serviceProvider.GetService(objectType);

                return contract;
            }

            return base.CreateObjectContract(objectType);
        }

        private JsonObjectContract ResolveContact(Type objectType)
        {
            var fType = this.metadata.GetType(objectType);
            return fType != null ? base.CreateObjectContract(fType) : CreateObjectContract(objectType);
        }
    }
}
