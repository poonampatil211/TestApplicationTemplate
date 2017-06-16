using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Connector.Hotels.Model.Metadata;
using Tavisca.Platform.Common.Logging;

namespace Tavisca181.Host.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogWriter _logwriter;
        protected readonly IHotelMetadata _metadata;
        protected readonly JsonSerializerSettings _globalSerializerSettings;

        protected BaseController(IOptions<MvcJsonOptions> mvcJsonOptions, ILogWriter logwriter, IHotelMetadata metadata)
        {
            _globalSerializerSettings = mvcJsonOptions.Value.SerializerSettings;
            _logwriter = logwriter;
            _metadata = metadata;
        }

    }
}
