using System.IO;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Stubs.SupplierCall;
using Tavisca.Connector.Hotels.Model.RoomRates;
using Tavisca.Platform.Common.Configurations;

namespace Tavisca181.RoomRates
{
    public class HotelRoomRates : IHotelRoomRates
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISupplierCall _supplierCall;
        private readonly TransformRoomRates _transformRoomRates;

        public HotelRoomRates(IConfigurationProvider configurationProvider, ISupplierCall supplierCall, TransformRoomRates transformRoomRates)
        {
            _configurationProvider = configurationProvider;
            _supplierCall = supplierCall;
            _transformRoomRates = transformRoomRates;
        }

        public async Task<Response> GetRoomRatesAsync(Request request)
        {
            string supplierRequest = _transformRoomRates.TransformRoomRatesRequest(request);

            // Uncomment below line when connector is implemented.
            //string supplierResponse = _supplierCall.CallSupplierMethod(supplierRequest,
            //    _configurationProvider.GetGlobalConfigurationAsString(string.Empty, ConfigurationKeys.TestUrlKey)).GetAwaiter().GetResult();

            // Remove below line while implementing connector.
            string supplierResponse = File.ReadAllText(@"../Tavisca181/MockResponse/fetchRoomRates-response.json5");

            return _transformRoomRates.TransformRoomRatesResponse(supplierResponse);
        }
    }
}
