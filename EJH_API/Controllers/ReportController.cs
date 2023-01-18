using Microsoft.AspNetCore.Mvc;
using Logic.WriteServices;
using Logic.DTOs.Report;
using Logic.ReadServices.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    //[Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IReportReadService _ReportReadService;
        public ReportController(IReportReadService ReportReadService)
        {
            _ReportReadService = ReportReadService;
        }


        // GET api/<ReportController>
        [HttpGet]
        public async Task<ActionResult<List<GenericReportResponse>>> Get()
        {
            try
            {
                return Ok();

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // GET api/<ReportController>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GenericReportResponse>>> Get(Guid id)
        {
            try
            {
                return Ok();

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
