using System;
using System.Text.Json.Serialization;

namespace ee.Models
{
	public class Sight
	{
        public int Id { get; set; }
        public string Name { get; set; }

        public string Text { get; set; }

        public string Image { get; set; }


        public string Url { get; set; }

        public string Address { get; set; }

        public Sight(int id, string name, string text, string image, string url, string address)
		{
            Id = id;
            Name = name;
            Text = text;
            Image = image;
            Url = url;
            Address = address;
		}
	}
}

