using DataBase.Models;
using Logic.DTOs.Teacher;

namespace Logic.WriteServices.Interfaces
{
    public interface ITeacherWriteService
    {
        public void Add(Guid personId);
        public Teacher Update(Guid Id, UpdateTeacherRequest updateTeacherRequest);
        public Teacher Delete(Guid id);
    }
}
