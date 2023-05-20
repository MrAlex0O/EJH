using Logic.DTOs.Group;

namespace Logic.ReadServices.Interfaces
{
    public interface IGroupReadService
    {
        public Task<IEnumerable<GetGroupResponse>> GetAll();
        public Task<GetGroupResponse> Get(Guid id);
    }
}
