using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PracticeApp.Core.Models;

namespace PracticeApp.Core.Services
{
    public class RestService
    {
        HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                    Console.WriteLine("I should see this" + weatherData.Main.Temperature.ToString());
                }
            }catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);

                Debug.WriteLine("\t\tERROR {0} Diddn't wooooooooooooooooooork", ex.Message);

            }
            return weatherData;
        }
    }
}
