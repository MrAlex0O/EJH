using Logic.DTOs.StatusOnLesson;
using Logic.ReadServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusOnLessonController : ControllerBase
    {
        IStatusOnLessonReadService _statusOnLessonReadService;
        public StatusOnLessonController(IStatusOnLessonReadService statusOnLessonReadService)
        {
            _statusOnLessonReadService = statusOnLessonReadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetStatusOnLessonResponse>>> Get()
        {
            return Ok(await _statusOnLessonReadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStatusOnLessonResponse>> Get(Guid id)
        {
            return Ok(await _statusOnLessonReadService.Get(id));
        }
    }
}
