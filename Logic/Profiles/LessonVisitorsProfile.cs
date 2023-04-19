using AutoMapper;
using DataBase.Models;
using Logic.DTOs.LessonVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
