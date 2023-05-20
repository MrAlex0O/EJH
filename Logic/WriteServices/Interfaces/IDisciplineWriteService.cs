using Logic.DTOs.Discipline;

namespace Logic.WriteServices.Interfaces
{
    public interface IDisciplineWriteService
    {
        public Guid Add(CreateDisciplineRequest createDisciplineRequest);
        public void Update(Guid id, UpdateDisciplineRequest updateDisciplineRequest);
        public void Delete(Guid id);
    }
}
