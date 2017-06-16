using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Connector.Hotels.Model.Search;

namespace Tavisca181.Search
{
    public class TransformSearch
    {
        public string TransformSearchRequest(SearchRequest searchRequest)
        {
            // Connector - Code for transforming SearchRequest to supplier specific request

            return string.Empty;
        }

        public SearchResponse TransformSearchResponse(string searchResponse)
        {
            // Connector - Code for transforming supplier specific response to SearchResponse object

            return JsonConvert.DeserializeObject<SearchResponse>(searchResponse); ;
        }
    }
}
