using Raven.Client.Documents.Indexes;
using RavenDB_IndexGeneration.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenDB_13354.Issue.Indexes
{
    public class SubEntityCommaIndex : AbstractIndexCreationTask<Entity>
    {
       
        public SubEntityCommaIndex()
        {
            Map = entities => from e in entities
                              from subentity in e.SubEntityComma // subentity, hyphen -> not valid c# porperty name
                              select new
                              {
                                  name = e.Name
                              };
        }
    }
}
