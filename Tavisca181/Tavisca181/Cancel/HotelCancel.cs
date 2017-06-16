using System.IO;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Stubs.SupplierCall;
using Tavisca.Connector.Hotels.Model.Cancel;
using Tavisca.Platform.Common.Configurations;

namespace Tavisca181.Cancel
{
    public class HotelCancel : IHotelCancel
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISupplierCall _supplierCall;
        private readonly TransformCancel _transformCancel;

        public HotelCancel(IConfigurationProvider configurationProvider, ISupplierCall supplierCall, TransformCancel transformCancel)
        {
            _configurationProvider = configurationProvider;
            _supplierCall = supplierCall;
            _transformCancel = transformCancel;
        }

        public async Task<CancelResponse> CancelAsync(CancelRequest request)
        {
            string supplierRequest = _transformCancel.TransformCancelRequest(request);

            // Uncomment below line when connector is implemented.
            //string supplierResponse = _supplierCall.CallSupplierMethod(supplierRequest,
            //    _configurationProvider.GetGlobalConfigurationAsString(string.Empty, ConfigurationKeys.TestUrlKey)).GetAwaiter().GetResult();

            // Remove below line while implementing connector.
            string supplierResponse = File.ReadAllText(@"../Tavisca181/MockResponse/cancel-Response.json5");

            return _transformCancel.TransformCancelResponse(supplierResponse);
        }
    }
}
