using Logic.DTOs.Teacher;

namespace Logic.Queries.Interfaces
{
    public interface ITeacherQuery
    {
        public Task<IEnumerable<GetTeacherResponse>> GetAll();
        public Task<GetTeacherResponse> Get(Guid id);
    }
}
