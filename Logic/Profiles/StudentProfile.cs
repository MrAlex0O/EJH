using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Student;

namespace Logic.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentRequest, Person>();
            CreateMap<UpdateStudentRequest, Person>();
            CreateMap<UpdateStudentRequest, Student>();
        }
    }
}
