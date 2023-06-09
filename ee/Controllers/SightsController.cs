using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using ee.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ee.Controllers
{
    public class SightsController : Controller
    {
        private readonly HttpClient _httpClient;

        public SightsController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> View(double x, double y)
        {
            // Retrieve the stop details from your data source using the stopId
            //string apiUrl = GenerateQueryURL(x, x+1, y, y+1);
            string apiUrl = "https://services6.arcgis.com/fUWVlHWZNxUvTUh8/arcgis/rest/services/PLACES/FeatureServer/0/query?where=1%3D1&outFields=name,text,image,url,address&outSR=4326&f=json";
            try
            {
                // Send GET request to the API
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Read the API response as JSON string
                string apiResponse = await response.Content.ReadAsStringAsync();

                // TODO: Deserialize the JSON response to your C# models
                // You'll need to define appropriate models to match the API response structure
                ApiResponseSights places = JsonSerializer.Deserialize<ApiResponseSights>(apiResponse);
                SightsViewModel viewModel = new SightsViewModel();
                List<Sight> listOfSights = new List<Sight>();
                int index = 0;
                if (places.Features.Count == 0)
                {
                    return RedirectToAction("NoData");

                }
                foreach (var item in places.Features)
                {
                    index = index + 1;
                    Sight sight = new Sight(index ,item.Attributes.Name, item.Attributes.Text, item.Attributes.Image, item.Attributes.Url, item.Attributes.Address);
                    listOfSights.Add(sight);
                }
                viewModel.Sights.AddRange(GetRandomSubset(listOfSights));

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // TODO: ako sa robi error handling?
            }

            // Return a default view if no data or an error occurred
            return View();
        }

        public List<T> GetRandomSubset<T>(List<T> list)
        {
            // Create a random number generator
            Random random = new Random();

            // Shuffle the list
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = random.Next(i, list.Count);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            // Take the first 10 elements from the shuffled list
            List<T> subset = list.Take(10).ToList();

            return subset;
        }
        public IActionResult NoData()
        {
            return View();
        }

        public string GenerateQueryURL(double latitude1, double latitude2, double longitude1, double longitude2)
        {
            string baseURL = "https://services6.arcgis.com/fUWVlHWZNxUvTUh8/arcgis/rest/services/PLACES/FeatureServer/0/query";
            string whereClause = $"(latitude%20%3D%20{latitude1.ToString().Replace(',', '.')}%20OR%20latitude%20%3D%20{latitude2.ToString().Replace(',', '.')})%20AND%20(longitude%20%3D%20{longitude1.ToString().Replace(',', '.')}%20OR%20longitude%20%3D%20{longitude2.ToString().Replace(',', '.')})";
            string outFields = "name,text,image,tickets,url,latitude,longitude";
            string outSR = "4326";
            string format = "json";

            string url = $"{baseURL}?where={whereClause}&outFields={outFields}&outSR={outSR}&f={format}";
            return url;
        }

        public IActionResult Details(string name, string text, string address)
        {
            Sight sight = new Sight(0, name, text, "null", "null", address);
            return View(sight);
        }
    }
}

