namespace App.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Threading.Tasks;
    using App.Infrastructure.Entities;

    public interface IRepository<T> : IDisposable where T : class, IEntity
    {
        Task<bool> Add(T entity);
    }
}
