using Newtonsoft.Json;
using Tavisca.Connector.Hotels.Model.RoomRates;


namespace Tavisca181.RoomRates
{
    public class TransformRoomRates
    {
        public string TransformRoomRatesRequest(Request roomRatesRequest)
        {
            // Connector - Code for transforming RoomRates Request to supplier specific request

            return string.Empty;
        }

        public Response TransformRoomRatesResponse(string roomRatesResponse)
        {
            // Connector - Code for transforming supplier specific response to RoomRates Response object

            return JsonConvert.DeserializeObject<Response>(roomRatesResponse); ;
        }
    }
}
