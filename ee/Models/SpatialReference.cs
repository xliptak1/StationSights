using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class SpatialReference
	{
        [JsonPropertyName("wkid")]
        public long Wkid { get; set; }

        [JsonPropertyName("latestWkid")]
        public long LatestWkid { get; set; }
        public SpatialReference()
		{
		}
	}
}

