using System.IO;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Stubs.SupplierCall;
using Tavisca.Connector.Hotels.Model.Search;
using Tavisca.Platform.Common.Configurations;

namespace Tavisca181.Search
{
    public class HotelSearch : IHotelSearch
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISupplierCall _supplierCall;
        private readonly TransformSearch _transformSearch;
       
        public HotelSearch(IConfigurationProvider configurationProvider, ISupplierCall supplierCall, TransformSearch transformSearch)
        {
            _configurationProvider = configurationProvider;
            _supplierCall = supplierCall;
            _transformSearch = transformSearch;
        }

        public async Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            string supplierRequest = _transformSearch.TransformSearchRequest(request);

            // Uncomment below line when connector is implemented.
            //string supplierResponse = _supplierCall.CallSupplierMethod(supplierRequest,
            //    _configurationProvider.GetGlobalConfigurationAsString(string.Empty, ConfigurationKeys.TestUrlKey)).GetAwaiter().GetResult();

            // Remove below line while implementing connector.
            string supplierResponse = File.ReadAllText(@"../Tavisca181/MockResponse/search-response.json5");

            return _transformSearch.TransformSearchResponse(supplierResponse);
        }
    }
}
