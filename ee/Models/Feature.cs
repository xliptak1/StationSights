using System;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ee.Models
{
	public class Feature
	{
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }
        public Feature()
		{
		}
	}
}

