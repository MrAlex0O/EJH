using DataBase.Models;

namespace Logic.WriteServices.Interfaces
{
    public interface IPersonWriteService
    {
        public Guid Add(Person person);
        public void Update(Guid id, Person person);
        public void Delete(Guid id);
    }
}
