using Microsoft.AspNetCore.Mvc;
using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Mappers.DtoMappers;

namespace theDeadlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDeadlineController : ControllerBase
    {
        private readonly ISubDeadlineService _subDeadlineService;
        public SubDeadlineController(ISubDeadlineService subDeadlineService)
        {
            _subDeadlineService = subDeadlineService;
        }

        [HttpPost("subdeadline")]
        public async Task<IActionResult> CreateSubDeadlineAsync([FromBody] SubDeadlineDto subDeadline)
        {
            var createdSubDeadline = await _subDeadlineService.CreateSubDeadlineAsync(subDeadline.MapToModel());
            return Ok(createdSubDeadline);
        }
        [HttpPut("subdeadline")]
        public async Task<IActionResult> UpdateSubDeadlineAsync([FromBody] SubDeadlineDto subDeadline)
        {
            var updatedSubDeadline = await _subDeadlineService.UpdateSubDeadlineAsync(subDeadline.MapToModel());
            return Ok(updatedSubDeadline);
        }
        [HttpDelete("subdeadline/{id}")]
        public async Task<IActionResult> DeleteSubDeadlineAsync(Guid id)
        {
            var deletedSubDeadline = await _subDeadlineService.DeleteSubDeadlineAsync(id);
            return Ok(deletedSubDeadline);
        }
    }
}
