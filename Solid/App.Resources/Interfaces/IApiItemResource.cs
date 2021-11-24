namespace App.Domain.Resources
{
    public interface IApiItemResource
    {
        string Kind { get; set; }
        string Id { get; set; }
        string Etag { get; set; }
        string SelfLink { get; set; }
        IApiVolumeInfoResource VolumeInfo { get; set; }
        IApiSearchInfo SearchInfo { get; set; }
    }
}