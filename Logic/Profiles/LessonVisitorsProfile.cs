using AutoMapper;
using DataBase.Models;
using Logic.DTOs.LessonVisitor;

namespace Logic.Profiles
{
    public class LessonVisitorProfile : Profile
    {
        public LessonVisitorProfile()
        {
            CreateMap<CreateLessonVisitorRequest, LessonVisitor>();
            CreateMap<UpdateLessonVisitorRequest, LessonVisitor>();
        }
    }
}
