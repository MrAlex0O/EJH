using Logic.DTOs.Teacher;

namespace Logic.ReadServices.Interfaces
{
    public interface ITeacherReadService
    {
        public Task<IEnumerable<GetTeacherResponse>> GetAll();
        public Task<GetTeacherResponse> Get(Guid id);
    }
}
