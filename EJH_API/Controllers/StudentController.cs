using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Student;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IPersonWriteService _personWriteService;
        IStudentWriteService _studentWriteService;
        IStudentReadService _studentReadService;
        IMapper _mapper;
        public StudentController(IPersonWriteService personWriteService, IStudentWriteService studentWriteService, IMapper mapper, IStudentReadService studentReadService)
        {
            _personWriteService = personWriteService;
            _studentWriteService = studentWriteService;
            _studentReadService = studentReadService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetStudentResponse>>> Get()
        {
            return Ok(await _studentReadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentResponse>> Get(Guid id)
        {
            return Ok(await _studentReadService.Get(id));
        }

        [HttpGet("byGroupId/{groupId}")]
        public async Task<ActionResult<List<GetStudentResponse>>> GetByGroupId(Guid groupId)
        {
            return Ok(await _studentReadService.GetByGroupId(groupId));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateStudentRequest createStudentRequest)
        {
            Guid personId = _personWriteService.Add(_mapper.Map<Person>(createStudentRequest));
            _studentWriteService.Add(personId, createStudentRequest.GroupId);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateStudentRequest updateStudentRequest)
        {
            Guid personId = (Guid)_studentWriteService.Update(id, updateStudentRequest).PersonId;
            _personWriteService.Update(personId, _mapper.Map<Person>(updateStudentRequest));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Guid personId = (Guid)_studentWriteService.Delete(id).PersonId;
            _personWriteService.Delete(personId);
            return Ok();
        }
    }
}
