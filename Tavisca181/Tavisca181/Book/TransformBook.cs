using Newtonsoft.Json;
using Tavisca.Connector.Hotels.Model.Book;

namespace Tavisca181.Book
{
    public class TransformBook
    {
        public string TransformBookRequest(BookRequest bookRequest)
        {
            // Connector - Code for transforming BookRequest to supplier specific request

            return string.Empty;
        }

        public BookResponse TransformBookResponse(string bookResponse)
        {
            // Connector - Code for transforming supplier specific response to BookResponse object

            return JsonConvert.DeserializeObject<BookResponse>(bookResponse); ;
        }
    }
}