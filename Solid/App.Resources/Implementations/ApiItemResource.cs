namespace App.Domain.Resources
{
    public class ApiItemResource : IApiItemResource
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string Etag { get; set; }
        public string SelfLink { get; set; }
        public IApiVolumeInfoResource VolumeInfo { get; set; }
        public IApiSearchInfo SearchInfo { get; set; }
    }
}