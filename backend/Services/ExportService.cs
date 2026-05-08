using backend.Models;
using Newtonsoft.Json;

namespace backend.Services
{
    public class ExportService
    {
        public async Task ExportJson(
            CadParameters parameters
        )
        {
            var folderPath = "Exports";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName =
                $"bearing_housing_{DateTime.Now:yyyyMMdd_HHmmss}.json";

            var fullPath =
                Path.Combine(folderPath, fileName);

            var json =
                JsonConvert.SerializeObject(
                    parameters,
                    Formatting.Indented
                );

            await File.WriteAllTextAsync(
                fullPath,
                json
            );
        }
    }
}