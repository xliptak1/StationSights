using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class AttributesSights
	{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("tickets")]
        public object Tickets { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        public AttributesSights()
		{
		}
	}
}

