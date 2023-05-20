using AutoMapper;
using DataBase.Models;
using Logic.DTOs.Group;
namespace Logic.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<CreateGroupRequest, Group>();
            CreateMap<UpdateGroupRequest, Group>();
        }
    }
}
