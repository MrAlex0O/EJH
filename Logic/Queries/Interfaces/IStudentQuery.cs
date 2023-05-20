using Logic.DTOs.Student;

namespace Logic.Queries.Interfaces
{
    public interface IStudentQuery
    {
        public Task<IEnumerable<GetStudentResponse>> GetAll();
        public Task<GetStudentResponse> Get(Guid id);
        public Task<IEnumerable<GetStudentResponse>> GetByGroupId(Guid groupId);
    }
}
