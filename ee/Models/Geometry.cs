using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class Geometry
	{
        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }
        public Geometry()
		{
		}
	}
}

