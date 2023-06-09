using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class Stop
	{
        public string Name { get; set; }
		public int Index { get; set; }
        public string Id { get; set; }
        public Geometry Geometry = new Geometry();

        public Stop(string name, string id, double x, double y, int index)
		{
			Name = name;
			Id = id;
			Geometry.X = x;
			Geometry.Y = y;
			Index = index;
		}
	}
}

