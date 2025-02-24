using Microsoft.AspNetCore.Mvc;
using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Mappers.DtoMappers;

namespace theDeadlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        [HttpGet("checklists")]
        public async Task<IActionResult> GetChecklistsAsync()
        {
            var checklists = await _checklistService.GetChecklistsAsync();
            return Ok(checklists);
        }

        [HttpGet("checklist/{id}")]
        public async Task<IActionResult> GetChecklistAsync(Guid id)
        {
            var checklist = await _checklistService.GetChecklistAsync(id);
            return Ok(checklist);
        }

        [HttpPost("checklist")]
        public async Task<IActionResult> CreateChecklistAsync([FromBody] ChecklistDto checklist)
        {
            var createdChecklist = await _checklistService.CreateChecklistAsync(checklist.MapToModel());
            return Ok(createdChecklist);
        }

        [HttpPut("checklist")]
        public async Task<IActionResult> UpdateChecklistAsync([FromBody] ChecklistDto checklist)
        {
            var updatedChecklist = await _checklistService.UpdateChecklistAsync(checklist.MapToModel());
            return Ok(updatedChecklist);
        }

        [HttpDelete("checklist/{id}")]
        public async Task<IActionResult> DeleteChecklistAsync(Guid id)
        {
            var deletedChecklist = await _checklistService.DeleteChecklistAsync(id);
            return Ok(deletedChecklist);
        }
    }
}
