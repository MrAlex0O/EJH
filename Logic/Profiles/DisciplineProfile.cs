using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Discipline;

namespace Logic.Profiles
{
    public class DisciplineProfile : Profile
    {
        public DisciplineProfile()
        {
            CreateMap<CreateDisciplineRequest, Discipline>();
            CreateMap<UpdateDisciplineRequest, Discipline>();
        }
    }
}
