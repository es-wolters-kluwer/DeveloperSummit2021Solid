namespace App.Domain.Entities
{
    using App.Infrastructure.Entities;

    public interface ISearchResultEntity : IEntity
    {
        string SearchText { get; set; }
        string Name { get; set; }
        string Result { get; set; }    }
}
