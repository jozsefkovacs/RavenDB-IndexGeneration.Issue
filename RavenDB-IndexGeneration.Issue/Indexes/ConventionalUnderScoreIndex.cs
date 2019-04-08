using Raven.Client.Documents.Indexes;
using RavenDB_IndexGeneration.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenDB_13354.Issue.Indexes
{
    public class ConventionalUnderScoreIndex : AbstractIndexCreationTask<Entity>
    {
       
        public ConventionalUnderScoreIndex()
        {
            Map = entities => from e in entities
                              from subentity in e.Conv__entional // conv_entional -> not valid c# porperty name
                              select new
                              {
                                  name = e.Name
                              };
        }
    }
}
