using Newtonsoft.Json;
using System.Collections.Generic;

namespace RavenDB_IndexGeneration.Issue
{
    public class Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Name-hyphen")]
        public string NameHypen { get; set; }

        [JsonProperty(PropertyName = "Name, hyphen")]
        public string NameComma { get; set; }

        [JsonProperty(PropertyName = "subentity, hyphen")]
        public List<SubEntity> SubEntityComma { get; set; }

        [JsonProperty(PropertyName = "conventional")]
        public List<SubEntity> Conventional { get; set; }

        [JsonProperty(PropertyName = "conv-entional")]
        public List<SubEntity> Conv_entional { get; set; }

        [JsonProperty(PropertyName = "conv_entional")]
        public List<SubEntity> Conv__entional { get; set; }

    }

    public class SubEntity
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Name-hyphen")]
        public string NameHypen { get; set; }

        [JsonProperty(PropertyName = "Name, hyphen")]
        public string NameComma { get; set; }
    }
}
