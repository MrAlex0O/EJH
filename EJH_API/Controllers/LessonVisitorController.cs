using Logic.DTOs.LessonVisitor;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonVisitorController : ControllerBase
    {
        ILessonVisitorWriteService _lessonVisitorWriteService;
        ILessonVisitorReadService _lessonVisitorsReadService;
        public LessonVisitorController(ILessonVisitorWriteService groupWriteService, ILessonVisitorReadService lessonVisitorsReadService)
        {
            _lessonVisitorWriteService = groupWriteService;
            _lessonVisitorsReadService = lessonVisitorsReadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLessonVisitorResponse>>> Get()
        {
            return Ok(await _lessonVisitorsReadService.GetAll());
        }

        [HttpGet("byLessonId/{id}")]
        public async Task<ActionResult<GetLessonVisitorResponse>> Get(Guid id)
        {
            return Ok(await _lessonVisitorsReadService.GetByLessonId(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLessonVisitorRequest createLessonVisitorRequest)
        {
            _lessonVisitorWriteService.Add(createLessonVisitorRequest);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLessonVisitorRequest updateLessonVisitorRequest)
        {
            _lessonVisitorWriteService.Update(id, updateLessonVisitorRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            _lessonVisitorWriteService.Delete(id);
            return Ok();
        }
    }
}
