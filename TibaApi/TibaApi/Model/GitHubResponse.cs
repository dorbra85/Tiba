using Newtonsoft.Json;
using System.Collections.Generic;

namespace TibaApi.Model
{
    public class GitHubResponse
    {
        public IEnumerable<Repository> Items { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }
        
    }
}
