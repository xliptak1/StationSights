using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class Attributes
	{
        [JsonPropertyName("stop_id")]
        public string StopId { get; set; }

        [JsonPropertyName("stop_name")]
        public string StopName { get; set; }

        public Attributes()
		{
		}
	}
}

