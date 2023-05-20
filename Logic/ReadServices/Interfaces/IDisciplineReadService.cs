using Logic.DTOs.Discipline;

namespace Logic.ReadServices.Interfaces
{
    public interface IDisciplineReadService
    {
        public Task<IEnumerable<GetDisciplineResponse>> GetAll();
        public Task<GetDisciplineResponse> Get(Guid id);
        public Task<IEnumerable<GetDisciplineResponse>> GetByTeacherId(Guid TeacherId);
    }
}
