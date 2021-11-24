namespace App.Domain.Business
{
    using System;
    using App.Domain.Entities;
    using App.Domain.Resources;
    using Microsoft.Extensions.DependencyInjection;

    public class SearchResultEntityMapper : ISearchResultEntityMapper
    {
        private readonly IServiceProvider serviceProvider;

        public SearchResultEntityMapper(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISearchResultEntity Map(IApiItemResource source, string search)
        {
            ISearchResultEntity entity = this.serviceProvider.GetService<ISearchResultEntity>();

            entity.Id = Guid.NewGuid();
            entity.Name = source.VolumeInfo.Title;
            entity.SearchText = search;
            entity.Version = DateTime.UtcNow;
            entity.Result = source.SearchInfo.TextSnippet;

            return entity;
        }
    }
}
