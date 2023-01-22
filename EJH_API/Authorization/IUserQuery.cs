namespace API.Authorization
{
    public interface IUserQuery
    {
        public List<string> GetRolesByUser(Guid id);
    }
}
