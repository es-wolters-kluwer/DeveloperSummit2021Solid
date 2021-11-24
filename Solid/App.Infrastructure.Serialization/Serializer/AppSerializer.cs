namespace App.Infrastructure.Serialization
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    public class AppSerializer : IAppSerializer
    {
        private JsonSerializer serializer;
        public AppSerializer(IAppContractResolver contractResolver)
        {
            if (contractResolver == null) throw new ArgumentNullException(nameof(contractResolver));

            this.serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.DateTime,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                ContractResolver = contractResolver,
                MissingMemberHandling = MissingMemberHandling.Ignore,
            };
        }

        public T Deserialize<T>(string jsonText) where T : class
        {
            using TextReader sr = new StringReader(jsonText);
            using JsonReader reader = new JsonTextReader(sr);

            return  serializer.Deserialize<T>(reader);
        }

        public string Serialize(object source)
        {
            using var writer = new StringWriter();
            using var jsonWriter = new JsonTextWriter(writer);

            serializer.Serialize(jsonWriter, source);
            return writer.ToString();
        }

        public void Dispose()
        {
            this.serializer = null;
        }
    }
}
