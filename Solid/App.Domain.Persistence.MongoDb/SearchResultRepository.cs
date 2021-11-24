namespace App.Domain.Persistence.MongoDb
{
    using System.Threading.Tasks;
    using App.Domain.Entities;
    using App.Infrastructure.Persistence.Repositories;
    using MongoDB.Driver;

    public class SearchResultRepository : IRepository<ISearchResultEntity>
    {
        private readonly IMongoClient client;
        private readonly string databaseName;
        private readonly string collection;

        public SearchResultRepository(MongoConfig config)
        {
            this.client = new MongoClient(config.ConnectionString);
            this.databaseName = config.Persistence.DatabaseName;
            this.collection = config.Persistence.Collections.Find(x => x.Type == typeof(ISearchResultEntity).Name)?.Name;
        }

        public async Task<bool> Add(ISearchResultEntity entity)
        {
            var db = this.client.GetDatabase(this.databaseName);

            IMongoCollection<ISearchResultEntity> mongoCollection = db.GetCollection<ISearchResultEntity>(this.collection);

            await mongoCollection.InsertOneAsync(entity).ConfigureAwait(false);

            return true;
        }

        public void Dispose()
        {
        }
    }
}
