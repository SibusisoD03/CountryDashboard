using CountryDashboardSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryDashboardSystem.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TResult>> GetCountries()
        {
            var response = await _httpClient.GetAsync("http://api.worldbank.org/v2/country");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<CountryResult>(responseStream);

            return responseObject?.countries.country.Select(x => new TResult
            {
                IsoCode = x.iso2Code,
                CountryName = x.name,
                Region = x.region,
                AdminRegion = x.adminregion,
                IncomeLevel = x.incomeLevel,
                LendingType = x.lendingType,
                CapitalCity = x.capitalCity,
                Longitude = x.longitude,
                Latitude = x.latitude
            });
        }


    }
}
