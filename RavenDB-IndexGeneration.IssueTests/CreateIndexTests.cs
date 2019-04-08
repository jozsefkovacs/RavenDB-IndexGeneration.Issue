using Raven.Client.Documents;
using RavenDB_13354.Issue.Indexes;
using RavenDB_IndexGeneration.Issue;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RavenDB_IndexGeneration.IssueTests
{
    [Collection(Globals.InjectGlobalFixture)]
    public class CreateIndexTests
    {
        private readonly GlobalSetupFixture _global;

        public CreateIndexTests(GlobalSetupFixture global) => _global = global;


        [Fact(DisplayName = "Should be able to save Index : ConventionalHyphenIndex")]
        public void InsertIndexTest_ConventionalHyphenIndex()
        {
            ReadRepository readRepository = new ReadRepository(_global._appSettings);

            readRepository.RegisterIndex(new ConventionalHyphenIndex());
        }


        [Fact(DisplayName = "Should be able to save Index : ConventionalIndex")]
        public void InsertIndexTest_ConventionalIndex()
        {
            ReadRepository readRepository = new ReadRepository(_global._appSettings);

            readRepository.RegisterIndex(new ConventionalIndex());
        }


        [Fact(DisplayName = "Should be able to save Index : ConventionalUnderScoreIndex")]
        public void InsertIndexTest_ConventionalUnderScoreIndex()
        {
            ReadRepository readRepository = new ReadRepository(_global._appSettings);

            readRepository.RegisterIndex(new ConventionalUnderScoreIndex());
        }


        [Fact(DisplayName = "Should be able to save Index : SubEntityCommaIndex")]
        public void InsertIndexTest_SubEntityCommaIndex()
        {
            ReadRepository readRepository = new ReadRepository(_global._appSettings);

            readRepository.RegisterIndex(new SubEntityCommaIndex());
        }

    }
}
