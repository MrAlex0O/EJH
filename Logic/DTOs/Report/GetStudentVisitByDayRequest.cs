namespace Logic.DTOs.Report
{
    public class GetStudentVisitByDayRequest
    {
        public Guid StudentId { get; set; }
        public DateTime Date { get; set; }
    }
}
