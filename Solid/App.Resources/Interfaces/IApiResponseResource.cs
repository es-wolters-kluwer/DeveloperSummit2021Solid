namespace App.Domain.Resources
{
    public interface IApiResponseResource
    {
        string Kind { get; set; }
        double TotalItems { get; set; }
        IApiItemResource[] Items { get; set; }
    }
}