using Microsoft.AspNetCore.Mvc;
using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Mappers.DtoMappers;

namespace theDeadlines.API.Controllers
{
    public class ChecklistItemController : ControllerBase
    {
        private readonly IChecklistItemService _checklistItemService;

        public ChecklistItemController(IChecklistItemService checklistItemService)
        {
            _checklistItemService = checklistItemService;
        }

        [HttpPost("checklistitem")]
        public async Task<IActionResult> CreateChecklistItemAsync([FromBody] ChecklistItemDto checklistItem)
        {
            var createdChecklistItem = await _checklistItemService.CreateChecklistItemAsync(checklistItem.MapToModel());
            return Ok(createdChecklistItem);
        }

        [HttpPut("checklistitem")]
        public async Task<IActionResult> UpdateChecklistItemAsync([FromBody] ChecklistItemDto checklistItem)
        {
            var updatedChecklistItem = await _checklistItemService.UpdateChecklistItemAsync(checklistItem.MapToModel());
            return Ok(updatedChecklistItem);
        }

        [HttpDelete("checklistitem/{id}")]
        public async Task<IActionResult> DeleteChecklistItemAsync(Guid id)
        {
            var deletedChecklistItem = await _checklistItemService.DeleteChecklistItemAsync(id);
            return Ok(deletedChecklistItem);
        }
    }
}
