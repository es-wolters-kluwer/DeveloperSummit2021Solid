namespace App.Domain.Entities
{
    using System;

    public class SearchResultEntity : ISearchResultEntity
    {
        public Guid Id { get; set; }
        public DateTime Version { get; set; }
        public string SearchText { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
    }
}
