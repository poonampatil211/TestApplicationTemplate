using Microsoft.AspNetCore.Mvc;
using Tavisca.Platform.Common.Logging;
using Tavisca.Connector.Hotels.Service;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Model.Search;

namespace Tavisca181.Host.Controllers
{

    [Route("api/HotelSearch")]
    public class HotelSearchController : BaseController
    {
        private readonly IHotelSearch _hotelSearch;

        public HotelSearchController(IOptions<MvcJsonOptions> mvcJsonOptions, IHotelSearch hotelSearch, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {
            _hotelSearch = hotelSearch;
        }

        [HttpPost]
        public IActionResult SearchHotels()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }

            var searchRequest = JsonConvert.DeserializeObject<SearchRequest>(requestBody, _globalSerializerSettings);

            HotelSearchService searchService = new HotelSearchService(_hotelSearch, _logwriter, _metadata);
            var searchResponse = searchService.SearchHotels(searchRequest, HttpContext);
            return Ok(searchResponse);
        }

    }
}
