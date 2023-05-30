using API.Authorization.Attributes;
using Logic.DTOs.Discipline;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        IDisciplineWriteService _disciplineWriteService;
        IDisciplineReadService _disciplineReadService;
        IAssistantWriteService _assistantWriteService;
        public DisciplineController(IDisciplineWriteService disciplineWriteService, IDisciplineReadService disciplineReadService, IAssistantWriteService assistantWriteService)
        {
            _disciplineWriteService = disciplineWriteService;
            _disciplineReadService = disciplineReadService;
            _assistantWriteService = assistantWriteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetDisciplineResponse>>> Get()
        {
            return Ok(await _disciplineReadService.GetAll());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetDisciplineResponse>> Get(Guid id)
        {
            return Ok(await _disciplineReadService.Get(id));
        }

        [HttpGet("byTeacherId/{teacherId}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetDisciplineResponse>>> GetByTeacherId(Guid teacherId)
        {
            return Ok(await _disciplineReadService.GetByTeacherId(teacherId));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateDisciplineRequest createDisciplineRequest)
        {
            Guid disciplineId = _disciplineWriteService.Add(createDisciplineRequest);
            foreach (var assistantId in createDisciplineRequest.AssistantsIds)
            {
                _assistantWriteService.Add(disciplineId, assistantId);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateDisciplineRequest updateDisciplineRequest)
        {
            _disciplineWriteService.Update(id, updateDisciplineRequest);
            _assistantWriteService.DeleteByDisciplineId(id);
            foreach (var assistantId in updateDisciplineRequest.AssistantsIds)
            {
                _assistantWriteService.Add(id, assistantId);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(Guid id)
        {
            _disciplineWriteService.Delete(id);
            _assistantWriteService.DeleteByDisciplineId(id);
            return Ok();
        }
    }
}
