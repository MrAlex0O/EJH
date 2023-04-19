using Logic.DTOs.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface IReportReadService
    {
        public Task<IEnumerable<GetDisciplineVisitsReportResponse>> GetDisciplineVisits(Guid disciplineId);
        public Task<IEnumerable<GetStudentVisitsResponse>> GetDisciplineVisitsByStudentId(Guid studentId);
        public Task<IEnumerable<GetStudentVisitsResponse>> GetStudentVisitsByDay(GetStudentVisitByDayRequest request);
        public Task<IEnumerable<GetStudentVisitsResponse>> GetStudentVisitsByInterval(GetStudentVisitsByIntervalRequest request);

    }
}
