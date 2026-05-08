using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/prompt")]
    public class PromptController : ControllerBase
    {
        private readonly WorkflowService _workflowService;

        public PromptController(
            WorkflowService workflowService
        )
        {
            _workflowService = workflowService;
        }

        [HttpPost]
        public async Task<ActionResult<CadParameters>>
            Generate([FromBody] PromptRequest request)
        {
            var result =
                await _workflowService.ProcessPrompt(
                    request.Prompt
                );

            return Ok(result);
        }
    }
}