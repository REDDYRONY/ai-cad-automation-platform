using System.Text;
using Newtonsoft.Json;

namespace backend.Clients
{
    public class GeminiClient
    {
        private readonly HttpClient _httpClient;

        public GeminiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateEngineeringJson(string prompt)
        {
            var requestBody = new
            {
                model = "phi3:mini",

                prompt =
$@"You are an engineering parameter extraction AI.

Return ONLY valid JSON.

Extract:
- component
- shaft_diameter
- material
- mounting_holes

Prompt:
{prompt}",

                stream = false
            };

            var json = JsonConvert.SerializeObject(requestBody);

            var response = await _httpClient.PostAsync(
                "http://localhost:11434/api/generate",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            return await response.Content.ReadAsStringAsync();
        }
    }
}