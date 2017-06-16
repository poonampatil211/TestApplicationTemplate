using System.IO;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Stubs.SupplierCall;
using Tavisca.Connector.Hotels.Model.RateRules;
using Tavisca.Platform.Common.Configurations;

namespace Tavisca181.RateRules
{
    public class HotelRateRules : IHotelRateRules
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISupplierCall _supplierCall;
        private readonly TransformRateRules _transformRateRules;

        public HotelRateRules(IConfigurationProvider configurationProvider, ISupplierCall supplierCall, TransformRateRules transformRateRules)
        {
            _configurationProvider = configurationProvider;
            _supplierCall = supplierCall;
            _transformRateRules = transformRateRules;
        }

        public async Task<RateRulesResponse> GetRateRulesAsync(RateRulesRequest request)
        {
            string supplierRequest = _transformRateRules.TransformRateRulesRequest(request);

            // Uncomment below line when connector is implemented.
            //string supplierResponse = _supplierCall.CallSupplierMethod(supplierRequest,
            //    _configurationProvider.GetGlobalConfigurationAsString(string.Empty, ConfigurationKeys.TestUrlKey)).GetAwaiter().GetResult();

            // Remove below line while implementing connector.
            string supplierResponse = File.ReadAllText(@"../Tavisca181/MockResponse/fetchRateRules-response-perBooking.json5");

            return _transformRateRules.TransformRateRulesResponse(supplierResponse);
        }
    }
}
