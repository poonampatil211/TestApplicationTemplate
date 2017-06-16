using Newtonsoft.Json;
using Tavisca.Connector.Hotels.Model.RateRules;

namespace Tavisca181.RateRules
{
    public class TransformRateRules
    {
        public string TransformRateRulesRequest(RateRulesRequest rateRulesRequest)
        {
            // Connector - Code for transforming rateRules Request to supplier specific request

            return string.Empty;
        }

        public RateRulesResponse TransformRateRulesResponse(string rateRulesResponse)
        {
            // Connector - Code for transforming supplier specific response to rateRules Response object

            return JsonConvert.DeserializeObject<RateRulesResponse>(rateRulesResponse); ;
        }
    }
}
