using backend.Clients;
using backend.Models;
using backend.Rules;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace backend.Services
{
    public class WorkflowService
    {
        private readonly GeminiClient _geminiClient;

        private readonly ExportService _exportService;

        public WorkflowService(
            GeminiClient geminiClient,
            ExportService exportService
        )
        {
            _geminiClient = geminiClient;
            _exportService = exportService;
        }

        public async Task<CadParameters?> ProcessPrompt(
            string prompt
        )
        {
            var aiResponse =
                await _geminiClient.GenerateEngineeringJson(
                    prompt
                );

            var match = Regex.Match(
                aiResponse,
                @"\{[\s\S]*\}"
            );

            if (!match.Success)
            {
                return null;
            }

            var cleanJson = match.Value;

            var cadParameters =
                JsonConvert.DeserializeObject<CadParameters>(
                    cleanJson
                );

            if (cadParameters == null)
            {
                return null;
            }

            BearingHousingRules.Apply(
                cadParameters
            );

            await _exportService.ExportJson(
                cadParameters
            );

            return cadParameters;
        }
    }
}