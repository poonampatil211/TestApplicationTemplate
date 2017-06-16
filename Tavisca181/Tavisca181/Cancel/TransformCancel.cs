using Newtonsoft.Json;
using Tavisca.Connector.Hotels.Model.Cancel;

namespace Tavisca181.Cancel
{
    public class TransformCancel
    {
        public string TransformCancelRequest(CancelRequest cancelRequest)
        {
            // Connector - Code for transforming cancel Request to supplier specific request

            return string.Empty;
        }

        public CancelResponse TransformCancelResponse(string cancelResponse)
        {
            // Connector - Code for transforming supplier specific response to cancel Response object

            return JsonConvert.DeserializeObject<CancelResponse>(cancelResponse); ;
        }
    }
}
