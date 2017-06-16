using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Stubs.SupplierCall;
using Tavisca.Connector.Hotels.Model.Book;
using static Tavisca181.Common.SupplierConstants;
using Tavisca.Platform.Common.Configurations;

namespace Tavisca181.Book
{
    public class HotelBook : IHotelBook
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISupplierCall _supplierCall;
        private readonly TransformBook _transformBook;

        public HotelBook(IConfigurationProvider configurationProvider, ISupplierCall supplierCall, TransformBook transformBook)
        {
            _configurationProvider = configurationProvider;
            _supplierCall = supplierCall;
            _transformBook = transformBook;
        }

        public async Task<BookResponse> BookAsync(BookRequest request)
        {
            string supplierRequest = _transformBook.TransformBookRequest(request);

            // Uncomment below line when connector is implemented.
            //string supplierResponse = _supplierCall.CallSupplierMethod(supplierRequest,
            //    _configurationProvider.GetGlobalConfigurationAsString(string.Empty, ConfigurationKeys.TestUrlKey)).GetAwaiter().GetResult();

            // Remove below line while implementing connector.
            string supplierResponse = File.ReadAllText(@"../Tavisca181/MockResponse/book-response.json5");

            return _transformBook.TransformBookResponse(supplierResponse);
        }
    }
}
