using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Teacher;

namespace Logic.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherRequest, Person>();
            CreateMap<UpdateTeacherRequest, Person>();
            CreateMap<UpdateTeacherRequest, Teacher>();
        }
    }
}
