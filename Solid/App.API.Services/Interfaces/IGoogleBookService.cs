namespace App.Domain.API.Services
{
    using System;
    using System.Threading.Tasks;
    using App.Domain.Resources;

    /// <summary>
    /// Service for GoogleBook API
    /// </summary>
    public interface IGoogleBookService : IDisposable
    {
        /// <summary>
        /// Search on volumes service
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IApiResponseResource> SearchFromVolumes(string query);
    }
}
