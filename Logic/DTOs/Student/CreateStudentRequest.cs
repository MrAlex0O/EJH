namespace Logic.DTOs.Student
{
    public class CreateStudentRequest
    {
        public string Name { get; set; }
        public string? Midname { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid GroupId { get; set; }
    }
}
