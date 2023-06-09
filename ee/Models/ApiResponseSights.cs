using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class ApiResponseSights
	{
        [JsonPropertyName("objectIdFieldName")]
        public string ObjectIdFieldName { get; set; }

        [JsonPropertyName("uniqueIdField")]
        public UniqueIdField UniqueIdField { get; set; }

        [JsonPropertyName("globalIdFieldName")]
        public string GlobalIdFieldName { get; set; }

        [JsonPropertyName("geometryType")]
        public string GeometryType { get; set; }

        [JsonPropertyName("spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        [JsonPropertyName("fields")]
        public List<FieldSights> Fields { get; set; }

        [JsonPropertyName("features")]
        public List<FeatureSights> Features { get; set; }
        public ApiResponseSights()
		{
		}
	}
}

