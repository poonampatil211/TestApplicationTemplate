using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Service;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    [Route("api/HotelMetadata")]
    public class HotelMetadataController : BaseController
    {
        public HotelMetadataController(IOptions<MvcJsonOptions> mvcJsonOptions, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {

        }

        [HttpPost]
        public IActionResult MetadataHotel()
        {
            HotelMetadataService hotelMetadataService = new HotelMetadataService(_metadata, _logwriter);
            var metadataResponse = hotelMetadataService.GetMetadata();
            return new ObjectResult(metadataResponse);
        }
    }
}
