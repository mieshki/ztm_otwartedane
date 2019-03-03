using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ztm_otwartedane
{
    public partial class BusEstimatedTimeParser
    {
        [JsonProperty("delay")]
        public List<BusEstimatedTime> allArrives { get; set; }
    }

    public partial class BusEstimatedTime
    {
        [JsonProperty("delayInSeconds")]
        public long delayInSeconds { get; set; }

        [JsonProperty("estimatedTime")]
        public string estimatedTime { get; set; }

        [JsonProperty("headsign")]
        public string direction { get; set; }

        [JsonProperty("routeId")]
        public long number { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }

    public partial class BusEstimatedTimeParser
    {
        public static BusEstimatedTimeParser FromJson(string json) => JsonConvert.DeserializeObject<BusEstimatedTimeParser>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this BusEstimatedTimeParser self) => JsonConvert.SerializeObject(self);
    }
}
