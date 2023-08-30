using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wikipedia.Services.Interfaces;
using Wikipedia.Services.Models;

namespace Wikipedia.Services.Services
{
    public class FloatNumberStatisticService : IFloatNumberStatisticService
    {
        private readonly HttpClient _httpClient;

        public FloatNumberStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FloatNumberStatistic> GetFloatNumberStatistics(string term, string language)
        {
            string languageUrl = language.Substring(0, 2);
            var url = $"https://{languageUrl}.wikipedia.org/wiki/{term}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var floatNumbers = Regex.Matches(responseContent, @"\b\d+\.\d+\b");
            float minimum = float.MaxValue, maximum = float.MinValue, sum = 0, currentNumber;
            int count = 0;

            foreach (Match floatString in floatNumbers)
            {
                currentNumber = float.Parse(floatString.Value);
                minimum = Math.Min(minimum, currentNumber);
                maximum = Math.Max(maximum, currentNumber);
                sum += currentNumber;
                count++;
            }

            float average = (float)(count > 0 ? sum / count : 0.0);

            var statistics = new FloatNumberStatistic
            {
                MinimumNumber = minimum,
                MaximumNumber = maximum,
                Count = count,
                Average = average
            };

            return statistics;
        }
    }
}
