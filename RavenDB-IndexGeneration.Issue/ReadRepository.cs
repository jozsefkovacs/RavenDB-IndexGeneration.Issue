using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavenDB_IndexGeneration.Issue
{
    public class ReadRepository
    {
        private readonly IDocumentStore _store;
        private readonly AppSettings _appSettings;
        public ReadRepository(AppSettings appSettings)
        {
            _appSettings = appSettings ?? throw new ArgumentNullException("appSettings");
            IDocumentStore store = new DocumentStore
            {
                Urls = new[] { appSettings.RavenDbEndpoint },
                Database = appSettings.RavenThreatDb,
                Conventions =
                {
                }
            };

            store.Initialize();
            //IndexCreation.CreateIndexes(typeof(ReadRepository).Assembly, store);
            _store = store;

        }

        public ReadRepository(IDocumentStore store) => _store = store ?? throw new ArgumentNullException("store");

        public async Task<Entity> Save(Entity entity)
        {
            using (IAsyncDocumentSession session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<Entity> Get(string id)
        {
            using (IAsyncDocumentSession session = _store.OpenAsyncSession())
            {
                var docs = session.Query<Entity>()
                                  .Statistics(out QueryStatistics stats)
                                  .Where(t => t.Id == id);


                var result = await docs.ToListAsync();
                return result.FirstOrDefault();
            }
        }

        public IAsyncDocumentSession GetSessionForQuery() => _store.OpenAsyncSession();

        public void RegisterIndex(AbstractIndexCreationTask type)
        {
            IndexCreation.CreateIndexes(new List<AbstractIndexCreationTask> { type }, _store);
        }
    }

    public class AppSettings
    {
        public string RavenDbEndpoint { get; set; }
        public string RavenThreatDb { get; set; }
    }
}
