using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Teacher;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        IPersonWriteService _personWriteService;
        ITeacherWriteService _teacherWriteService;
        ITeacherReadService _teacherReadService;
        IMapper _mapper;
        public TeacherController(IPersonWriteService personWriteService, ITeacherWriteService teacherWriteService, ITeacherReadService teacherReadService, IMapper mapper)
        {
            _personWriteService = personWriteService;
            _teacherWriteService = teacherWriteService;
            _teacherReadService = teacherReadService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTeacherResponse>>> Get()
        {
            return Ok(await _teacherReadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTeacherResponse>> Get(Guid id)
        {
            return Ok(await _teacherReadService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTeacherRequest createTeacherRequest)
        {
            Guid personId = _personWriteService.Add(_mapper.Map<Person>(createTeacherRequest));
            _teacherWriteService.Add(personId);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateTeacherRequest updateTeacherRequest)
        {
            Guid personId = (Guid)_teacherWriteService.Update(id, updateTeacherRequest).PersonId;
            _personWriteService.Update(personId, _mapper.Map<Person>(updateTeacherRequest));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Guid personId = (Guid)_teacherWriteService.Delete(id).PersonId;
            _personWriteService.Delete(personId);
            return Ok();
        }
    }
}
