using Raven.Client.Documents.Indexes;
using RavenDB_IndexGeneration.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenDB_13354.Issue.Indexes
{
    public class ConventionalHyphenIndex : AbstractIndexCreationTask<Entity>
    {
       
        public ConventionalHyphenIndex()
        {
            Map = entities => from e in entities
                              from subentity in e.Conv_entional // conv-entional -> not valid c# porperty name
                              select new
                              {
                                  name = e.Name
                              };
        }
    }
}
