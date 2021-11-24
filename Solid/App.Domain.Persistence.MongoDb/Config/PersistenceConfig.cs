namespace App.Domain.Persistence.MongoDb
{
    using System.Collections.Generic;

    public class PersistenceConfig
    {
        public string DatabaseName { get; set; }
        public List<Collections> Collections { get; set; }
    }
}
