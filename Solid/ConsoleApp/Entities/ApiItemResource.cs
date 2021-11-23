namespace ConsoleApp.Entities
{
    public class ApiItemResource
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string Etag { get; set; }
        public string SelfLink { get; set; }
        public ApiVolumeInfoResource VolumeInfo { get; set; }
        public ApiSearchInfo SearchInfo { get; set; }
    }
}