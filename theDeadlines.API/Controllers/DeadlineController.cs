using Microsoft.AspNetCore.Mvc;
using theDeadlines.Abstraction.DTOs;
using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IServices;
using theDeadlines.DAL.Mappers.DtoMappers;

namespace theDeadlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeadlineController : ControllerBase
    {
        private readonly IDeadlineService _deadlineService;

        public DeadlineController(IDeadlineService deadlineService)
        {
            _deadlineService = deadlineService;
        }

        [HttpGet("deadlines")]
        public async Task<IActionResult> GetDeadlinesAsync()
        {
            var deadlines = await _deadlineService.GetDeadlinesAsync();
            return Ok(deadlines);
        }

        [HttpGet("deadline/{id}")]
        public async Task<IActionResult> GetDeadlineAsync(Guid id)
        {
            var deadline = await _deadlineService.GetDeadlineAsync(id);
            return Ok(deadline);
        }

        [HttpPost("deadline")]
        public async Task<IActionResult> CreateDeadlineAsync([FromBody] DeadlineDto deadline)
        {
            var createdDeadline = await _deadlineService.CreateDeadlineAsync(deadline.MapToModel());
            return Ok(createdDeadline);
        }

        [HttpPut("deadline")]
        public async Task<IActionResult> UpdateDeadlineAsync([FromBody] DeadlineDto deadline)
        {
            var updatedDeadline = await _deadlineService.UpdateDeadlineAsync(deadline.MapToModel());
            return Ok(updatedDeadline);
        }

        [HttpDelete("deadline/{id}")]
        public async Task<IActionResult> DeleteDeadlineAsync(Guid id)
        {
            var deletedDeadline = await _deadlineService.DeleteDeadlineAsync(id);
            return Ok(deletedDeadline);
        }
    }
}
