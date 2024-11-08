using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Algorithms
{
    class ExchangeRates
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiKey = "b99973d7db8909fc842d16b9affe76e0";
        private const string BaseUrl = "http://api.currencylayer.com/live";

        public static async Task<double> GetExchangeRateAsync(string fromCurrency, string toCurrency)
        {
            try
            {
                // Construct the request URL
                string url = $"{BaseUrl}?access_key={ApiKey}&currencies={fromCurrency},{toCurrency}";

                // Send HTTP GET request
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read response content as JSON
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(jsonResponse);

                // Check if the API response was successful
                if (data["success"].Value<bool>() == false)
                {
                    throw new Exception("Failed to retrieve exchange rates. Please check your API key and request parameters.");
                }

                // Extract the exchange rate (e.g., "USDEUR" for USD to EUR)
                string key = $"{fromCurrency}{toCurrency}";
                if (data["quotes"]?[key] == null)
                {
                    throw new Exception($"Exchange rate for {fromCurrency} to {toCurrency} not found.");
                }

                double exchangeRate = data["quotes"][key].Value<double>();
                return exchangeRate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }
}
