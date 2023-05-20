using Logic.DTOs.Discipline;

namespace Logic.Queries.Interfaces
{
    public interface IDisciplineQuery
    {
        public Task<IEnumerable<GetDisciplineResponse>> GetAll();
        public Task<GetDisciplineResponse> Get(Guid id);
        public Task<IEnumerable<GetDisciplineResponse>> GetByTeacherId(Guid teacherId);
    }
}
