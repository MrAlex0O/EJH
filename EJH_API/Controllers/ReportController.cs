﻿using Microsoft.AspNetCore.Mvc;
using Logic.WriteServices;
using Logic.DTOs.Report;
using Logic.ReadServices.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<ReportController>
        [HttpGet("disciplineVisits/{id}")]
        public async Task<ActionResult<GetDisciplineVisitsReportResponse>> GetDisciplineVisitsReport(Guid id)
        {
            try
            {
                return Ok(_reportReadService.GetDisciplineVisits(id));

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        

    }
}
