namespace App.Domain.Persistence.MongoDb.Mappings
{
    using App.Domain.Entities;
    using App.Domain.Persistence.MongoDb.Utils;

    public class EntityMapping : IMongoMapping
    {
        public void CreateMap()
        {
            RegisterEntityUtil.Register<ISearchResultEntity, SearchResultEntity>();
        }
    }
}
