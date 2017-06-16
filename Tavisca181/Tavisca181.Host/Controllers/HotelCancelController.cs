using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Connector.Hotels.Model.Cancel;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Service;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    [Route("api/HotelCancel")]
    public class HotelCancelController : BaseController
    {
        private readonly IHotelCancel _hotelCancel;

        public HotelCancelController(IOptions<MvcJsonOptions> mvcJsonOptions, IHotelCancel hotelCancel, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {
            _hotelCancel = hotelCancel;
        }

        [HttpPost]
        public IActionResult CancelHotel()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }

            var cancelRequest = JsonConvert.DeserializeObject<CancelRequest>(requestBody, _globalSerializerSettings);
            HotelCancelService hotelCancelService = new HotelCancelService(_hotelCancel, _logwriter, _metadata);
            var cancelResponse = hotelCancelService.CancelHotel(cancelRequest, HttpContext);
            return new ObjectResult(cancelResponse);
        }
    }
}
