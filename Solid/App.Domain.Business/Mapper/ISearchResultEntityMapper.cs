namespace App.Domain.Business
{
    using System;
    using App.Domain.Entities;
    using App.Domain.Resources;

    public interface ISearchResultEntityMapper : IDisposable
    {
        ISearchResultEntity Map(IApiItemResource source, string search);
    }
}
