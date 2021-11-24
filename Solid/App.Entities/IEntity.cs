namespace App.Infrastructure.Entities
{
    using System;

    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime Version { get; set; }
    }
}
