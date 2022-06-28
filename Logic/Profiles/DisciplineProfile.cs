﻿using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Discipline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
