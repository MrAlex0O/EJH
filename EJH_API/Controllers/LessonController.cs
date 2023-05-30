using Logic.DTOs.Lesson;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        ILessonWriteService _lessonWriteService;
        IAssistantWriteService _assistantWriteService;
        ILessonReadService _lessonReadService;
        public LessonController(ILessonWriteService lessonWriteService, IAssistantWriteService assistantWriteService, ILessonReadService lessonReadService)
        {
            _lessonWriteService = lessonWriteService;
            _assistantWriteService = assistantWriteService;
            _lessonReadService = lessonReadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLessonResponse>>> Get()
        {
            return Ok(await _lessonReadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLessonResponse>> Get(Guid id)
        {
            return Ok(await _lessonReadService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLessonRequest createLessonRequest)
        {
            Guid lessonId = _lessonWriteService.Add(createLessonRequest);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLessonRequest updateLessonRequest)
        {
            _lessonWriteService.Update(id, updateLessonRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            _lessonWriteService.Delete(id);
            return Ok();
        }
    }
}
