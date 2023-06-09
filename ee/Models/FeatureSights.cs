using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class FeatureSights
	{
        [JsonPropertyName("attributes")]
        public AttributesSights Attributes { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }
        public FeatureSights()
		{
		}
	}
}

