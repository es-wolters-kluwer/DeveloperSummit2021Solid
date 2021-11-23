namespace ConsoleApp.Entities
{
    public class ApiVolumeInfoResource
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string[] Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public string PageCount { get; set; }
        public string PrintType { get; set; }
        public string[] Categories { get; set; }
        public string MaturityRating { get; set; }
        public string Language { get; set; }
        public string PreviewLink { get; set; }
        public string InfoLink { get; set; }
        public string CanonicalVolumeLink { get; set; }
    }
}