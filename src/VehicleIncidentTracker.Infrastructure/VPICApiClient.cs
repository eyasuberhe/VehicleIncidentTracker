using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.Core.Interfaces;

namespace VehicleIncidentTracker.Infrastructure
{
    public class VPICApiClient : IVehicleService
    {
        private readonly string _apiUrl;
        private readonly HttpClient _client;

        public VPICApiClient(IConfiguration configuration) // string apiUrl = "https://vpic.nhtsa.dot.gov/")
        {
            _apiUrl = configuration.GetSection("baseUrls:vpicApiBase").Value;
            _client = new HttpClient { BaseAddress = new Uri(_apiUrl) };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Vehicle> DecodeVin(string vin)
        {
            var response = await _client.GetAsync($"/api/vehicles/decodevinvalues/{vin}?format=json");

            response.EnsureSuccessStatusCode();

            var vinDecodeResponse = JsonConvert.DeserializeObject<VINDecodeResponse>(await response.Content.ReadAsStringAsync());
            var result = vinDecodeResponse.Results.FirstOrDefault();

            return new Vehicle(result.VIN, result.Make, result.Model, result.ModelYear);
        }
    }
}
