using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Service;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    [Route("api/HotelMetadata")]
    public class HotelConfigSpecController : BaseController
    {
        public HotelConfigSpecController(IOptions<MvcJsonOptions> mvcJsonOptions, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {

        }

        [HttpPost]
        public IActionResult ConfigSpecHotel()
        {
            HotelMetadataService hotelMetadataService = new HotelMetadataService(_metadata, _logwriter);
            var configSpecResponse = hotelMetadataService.GetConfigurationSpec();
            return new ObjectResult(configSpecResponse);
        }
    }
}
