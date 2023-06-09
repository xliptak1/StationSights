using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ee.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ee.Controllers
{
    public class StopsListController : Controller
    {
        // GET: /<controller>/
        private readonly HttpClient _httpClient;

        public StopsListController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://services6.arcgis.com/fUWVlHWZNxUvTUh8/arcgis/rest/services/stops/FeatureServer/0/query?where=zone_id%20%3E%3D%20100%20AND%20zone_id%20%3C%3D%20101&outFields=stop_id,stop_name&outSR=4326&f=json";

            try
            {
                // Send GET request to the API
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Read the API response as JSON string
                string apiResponse = await response.Content.ReadAsStringAsync();

                // TODO: Deserialize the JSON response to your C# models
                // You'll need to define appropriate models to match the API response structure
                ApiResponse places = JsonSerializer.Deserialize<ApiResponse>(apiResponse);
                StopsViewModel viewModel = new StopsViewModel();
                int index = 0;
                foreach (var item in places.Features)
                {
                    index = index + 1;
                    Stop stop = new Stop(item.Attributes.StopName, item.Attributes.StopId, item.Geometry.X, item.Geometry.Y, index);
                    viewModel.Stops.Add(stop);
                }
                

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // TODO: ako sa robi error handling?
            }

            // Return a default view if no data or an error occurred
            return View();
        }
    }
}

