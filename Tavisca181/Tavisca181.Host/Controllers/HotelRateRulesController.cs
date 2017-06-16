using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Connector.Hotels.Model.RateRules;
using Tavisca.Connector.Hotels.Service;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    [Route("api/HotelRateRules")]
    public class HotelRateRulesController : BaseController
    {
        private readonly IHotelRateRules _hotelRateRules;

        public HotelRateRulesController(IOptions<MvcJsonOptions> mvcJsonOptions, IHotelRateRules hotelRateRules, ILogWriter logwriter, IHotelMetadata metadata)
            : base(mvcJsonOptions, logwriter, metadata)
        {
            _hotelRateRules = hotelRateRules;
        }

        [HttpPost]
        public IActionResult RateRulesHotel()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }

            var rateRulesRequest = JsonConvert.DeserializeObject<RateRulesRequest>(requestBody, _globalSerializerSettings);
            HotelRateRulesService rateRulesService = new HotelRateRulesService(_hotelRateRules, _logwriter, _metadata);
            var rateRulesResponse = rateRulesService.RateRulesHotel(rateRulesRequest, HttpContext);
            return new ObjectResult(rateRulesResponse);
        }
    }
}
