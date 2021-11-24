namespace ConsoleApp
{
    using System;
    using System.Threading.Tasks;
    using App.Domain.API.Services;
    using App.Domain.Business;
    using App.Domain.Entities;
    using App.Infrastructure.Persistence.Repositories;

    public class Application
    {
        private readonly IGoogleBookService service;
        private readonly IRepository<ISearchResultEntity> repository;
        private readonly ISearchResultEntityMapper mapper;

        public Application(IGoogleBookService service, IRepository<ISearchResultEntity> repository, ISearchResultEntityMapper mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Run()
        {
            Console.WriteLine("Query the api https://www.googleapis.com/books/v1/");

            try
            {
                //Read parameters from console

                Console.Write("Insert search parameters and press enter: ");
                string search = Console.ReadLine();
                Console.WriteLine();

                if (String.IsNullOrWhiteSpace(search))
                    throw new Exception("Empty search terms");

                //Call API
                var resource = await this.service.SearchFromVolumes(search).ConfigureAwait(false);
                if (resource?.TotalItems == 0)
                    throw new Exception("Not items found");

                ISearchResultEntity entity = this.mapper.Map(resource.Items[0], search);

                await this.repository.Add(entity).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
