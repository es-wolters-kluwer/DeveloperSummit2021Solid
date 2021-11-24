namespace App.Domain.Resources
{
    public interface IApiVolumeInfoResource
    {
        string Title { get; set; }
        string Subtitle { get; set; }
        string[] Authors { get; set; }
        string Publisher { get; set; }
        string PublishedDate { get; set; }
        string Description { get; set; }
        string PageCount { get; set; }
        string PrintType { get; set; }
        string[] Categories { get; set; }
        string MaturityRating { get; set; }
        string Language { get; set; }
        string PreviewLink { get; set; }
        string InfoLink { get; set; }
        string CanonicalVolumeLink { get; set; }
    }
}