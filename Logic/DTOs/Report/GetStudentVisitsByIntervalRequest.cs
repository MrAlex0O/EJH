namespace Logic.DTOs.Report
{
    public class GetStudentVisitsByIntervalRequest
    {
        public Guid StudentId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
