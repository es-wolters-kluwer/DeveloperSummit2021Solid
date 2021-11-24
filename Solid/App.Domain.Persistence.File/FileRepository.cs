namespace App.Domain.Persistence.File
{
    using System;
    using System.Threading.Tasks;
    using App.Domain.Entities;
    using App.Infrastructure.Persistence.Repositories;
    using App.Infrastructure.Serialization;

    public class FileRepository : IRepository<ISearchResultEntity>
    {
        private readonly IAppSerializer serializer;

        public FileRepository(IAppSerializer serializer)
        {
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public async Task<bool> Add(ISearchResultEntity entity)
        {
            string json = this.serializer.Serialize(entity);
            try
            {
                await System.IO.File.WriteAllTextAsync($"{entity.SearchText}_{DateTime.Now.Ticks}.txt", json)
                    .ConfigureAwait(false);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Dispose()
        {
            this.serializer?.Dispose();
        }
    }
}
