namespace App.Domain.Persistence.MongoDb
{
    public class MongoConfig
    {
        public string ConnectionString { get; set; }
        public PersistenceConfig Persistence { get; set; }
    }
}
