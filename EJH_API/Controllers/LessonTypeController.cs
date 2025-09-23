using Logic.DTOs.LessonType;
using Logic.ReadServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonTypeController : ControllerBase
    {
        ILessonTypeReadService _lessonTypeReadService;
        public LessonTypeController(ILessonTypeReadService lessonTypeReadService)
        {
            _lessonTypeReadService = lessonTypeReadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLessonTypeResponse>>> Get()
        {
            return Ok(await _lessonTypeReadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLessonTypeResponse>> Get(Guid id)
        {
            return Ok(await _lessonTypeReadService.Get(id));
        }
    }
}
