using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Connector.Hotels.Model.Book;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Service;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    [Route("api/HotelBook")]
    public class HotelBookController : BaseController
    {
        private readonly IHotelBook _hotelBook;

        public HotelBookController(IOptions<MvcJsonOptions> mvcJsonOptions, IHotelBook hotelBook, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {
            _hotelBook = hotelBook;
        }

        [HttpPost]
        public IActionResult BookHotel()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }

            var bookRequest = JsonConvert.DeserializeObject<BookRequest>(requestBody, _globalSerializerSettings);
            HotelBookService hotelBookService = new HotelBookService(_hotelBook, _logwriter, _metadata);
            var bookResponse = hotelBookService.BookHotel(bookRequest, HttpContext);
            return new ObjectResult(bookResponse);
        }
    }
}
