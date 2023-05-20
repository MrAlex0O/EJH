using Logic.DTOs.Group;

namespace Logic.Queries.Interfaces
{
    public interface IGroupQuery
    {
        public Task<IEnumerable<GetGroupResponse>> GetAll();
        public Task<GetGroupResponse> Get(Guid id);
    }
}
