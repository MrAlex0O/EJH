using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Lesson;

namespace Logic.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<CreateLessonRequest, Lesson>();
            CreateMap<UpdateLessonRequest, Lesson>();
        }
    }
}
