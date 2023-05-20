using Logic.DTOs.Group;

namespace Logic.WriteServices
{
    public interface IGroupWriteService
    {
        public void Add(CreateGroupRequest createGroupRequest);
        public void Update(Guid id, UpdateGroupRequest updateGroupRequest);
        public void Delete(Guid id);
    }
}
