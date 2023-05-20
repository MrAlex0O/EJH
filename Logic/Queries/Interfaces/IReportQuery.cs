using Logic.DTOs.Report;

namespace Logic.Queries.Interfaces
{
    public interface IReportQuery
    {
        public Task<IEnumerable<GetDisciplineVisitsReportResponse>> GetDisciplineVisits(Guid disciplineId);
        public Task<IEnumerable<GetStudentVisitsResponse>> GetDisciplineVisitsByStudentId(Guid studentId);
        public Task<IEnumerable<GetStudentVisitsResponse>> GetStudentVisitsByDay(GetStudentVisitByDayRequest request);
        public Task<IEnumerable<GetStudentVisitsResponse>> GetStudentVisitsByInterval(GetStudentVisitsByIntervalRequest request);
    }
}
