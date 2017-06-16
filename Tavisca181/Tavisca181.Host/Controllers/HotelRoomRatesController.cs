using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Model.RoomRates;
using Tavisca.Connector.Hotels.Service;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    [Route("api/HotelRoomRates")]
    public class HotelRoomRatesController : BaseController
    {
        private readonly IHotelRoomRates _hotelRoomRates;

        public HotelRoomRatesController(IOptions<MvcJsonOptions> mvcJsonOptions, IHotelRoomRates hotelRoomRates, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {
            _hotelRoomRates = hotelRoomRates;
        }

        [HttpPost]
        public IActionResult RoomRatesHotel()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }

            var roomRatesRequest = JsonConvert.DeserializeObject<Request>(requestBody, _globalSerializerSettings);
            HotelRoomRatesService roomRatesService = new HotelRoomRatesService(_hotelRoomRates, _logwriter, _metadata);
            var roomRatesResponse = roomRatesService.RoomRatesHotel(roomRatesRequest, HttpContext);
            return new ObjectResult(roomRatesResponse);
        }
    }
}
