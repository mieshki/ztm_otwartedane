using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ztm_otwartedane
{
    public partial class BusStopParser
    {
        [JsonProperty("BusStops")]
        public BusStop[] BusStops { get; set; }
    }

    public partial class BusStop
    {
        [JsonProperty("stopId")]
        public int stopID { get; set; }

        [JsonProperty("stopCode")]
        public string stopCode { get; set; }

        [JsonProperty("stopDesc")]
        public string stopDesc { get; set; }

        public string stopName { get { return stopDesc + " " + stopCode; }  }
    }

    public partial class BusStopParser
    {
        public static BusStopParser FromJson(string json) => JsonConvert.DeserializeObject<BusStopParser>(json);
    }
}
 