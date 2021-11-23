namespace ConsoleApp.Entities
{
    using System;

    public class ApiResponseResource
    {
        public ApiResponseResource()
        {
            this.Items = Array.Empty<ApiItemResource>();
        }

        public string Kind { get; set; }
        public double TotalItems { get; set; }
        public ApiItemResource[] Items { get; set; }
    }
}