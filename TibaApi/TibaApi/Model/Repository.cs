using Newtonsoft.Json;

namespace TibaApi.Model
{
    public class Repository
    {
        [JsonProperty("Id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Private")]
        public bool Private { get; set; }
    }
}
