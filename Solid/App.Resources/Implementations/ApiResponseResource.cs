namespace App.Domain.Resources
{
    using System;

    public class ApiResponseResource : IApiResponseResource
    {
        public ApiResponseResource()
        {
            this.Items = Array.Empty<ApiItemResource>();
        }

        public string Kind { get; set; }
        public double TotalItems { get; set; }
        public IApiItemResource[] Items { get; set; }
    }
}