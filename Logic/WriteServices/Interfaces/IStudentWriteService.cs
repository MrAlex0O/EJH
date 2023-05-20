using DataBase.Models;
using Logic.DTOs.Student;

namespace Logic.WriteServices.Interfaces
{
    public interface IStudentWriteService
    {
        public void Add(Guid personId, Guid groupId);
        public Student Update(Guid id, UpdateStudentRequest updateStudentRequest);
        public Student Delete(Guid id);
    }
}
