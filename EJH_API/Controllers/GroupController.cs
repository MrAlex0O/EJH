using API.Authorization.Attributes;
using DataBase.Contexts;
using Logic.DTOs.Group;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        IGroupWriteService _groupWriteService;
        IGroupReadService _groupReadService;
        public GroupController(IGroupWriteService groupWriteService, IGroupReadService groupReadService)
        {
            _groupWriteService = groupWriteService;
            _groupReadService = groupReadService;
        }
        
        [RequireAuthorization(Roles.Admin, Roles.Headman)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGroupResponse>>> Get()
        {
            return Ok(await _groupReadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetGroupResponse>> Get(Guid id)
        {
            return Ok(await _groupReadService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateGroupRequest createGroupRequest)
        {
            _groupWriteService.Add(createGroupRequest);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateGroupRequest updateGroupRequest)
        {
            _groupWriteService.Update(id, updateGroupRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            _groupWriteService.Delete(id);
            return Ok();
        }
    }
}
