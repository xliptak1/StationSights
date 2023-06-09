﻿using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class UniqueIdField
	{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isSystemMaintained")]
        public bool IsSystemMaintained { get; set; }

        public UniqueIdField()
		{
		}
	}
}

