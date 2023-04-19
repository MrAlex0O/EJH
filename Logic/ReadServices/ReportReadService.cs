using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Enums;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Logic.Queries.Interfaces;
using Logic.DTOs.Report;

namespace Logic.ReadServices
{
    public class ReportReadService : IReportReadService
    {
        private IReportQuery _reportQuery;

        public ReportReadService(IReportQuery reportQuery)
        {
            _reportQuery = reportQuery;
        }

        public async Task<IEnumerable<GetDisciplineVisitsReportResponse>> GetDisciplineVisits(Guid disciplineId)
        {
            return await _reportQuery.GetDisciplineVisits(disciplineId);
        }
        public async Task<IEnumerable<GetStudentVisitsResponse>> GetDisciplineVisitsByStudentId(Guid studentId)
        {
            return await _reportQuery.GetDisciplineVisitsByStudentId(studentId);
        }

        public async Task<IEnumerable<GetStudentVisitsResponse>> GetStudentVisitsByDay(GetStudentVisitByDayRequest request)
        {
            return await _reportQuery.GetStudentVisitsByDay(request);
        }

        public async Task<IEnumerable<GetStudentVisitsResponse>> GetStudentVisitsByInterval(GetStudentVisitsByIntervalRequest request)
        {
            return await _reportQuery.GetStudentVisitsByInterval(request);
        }
    }
}