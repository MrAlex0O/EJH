using Logic.DTOs.Report;
using Logic.ReadServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportReadService _reportReadService;
        public ReportController(IReportReadService reportReadService)
        {
            _reportReadService = reportReadService;
        }

        [HttpGet("disciplineVisits/{id}")]
        public async Task<ActionResult<GetDisciplineVisitsReportResponse>> GetDisciplineVisitsReport(Guid id)
        {
            return Ok(await _reportReadService.GetDisciplineVisits(id));
        }

        [HttpGet("studentVisits/{id}")]
        public async Task<ActionResult<GetStudentVisitsResponse>> GetDisciplineVisitsByStudentId(Guid id)
        {
            return Ok(await _reportReadService.GetDisciplineVisitsByStudentId(id));
        }

        [HttpPost("studentVisitsByDay")]
        public async Task<ActionResult<GetStudentVisitsResponse>> GetStudentVisitsByDay(GetStudentVisitByDayRequest request)
        {
            return Ok(await _reportReadService.GetStudentVisitsByDay(request));
        }

        [HttpPost("studentVisitsByInterval")]
        public async Task<ActionResult<GetStudentVisitsResponse>> GetStudentVisitsByInterval(GetStudentVisitsByIntervalRequest request)
        {
            return Ok(await _reportReadService.GetStudentVisitsByInterval(request));
        }
    }
}
