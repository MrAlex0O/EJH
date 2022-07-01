using API.Authorization.Models;
using AutoMapper;
using DataBase.Models;

namespace API.Authorization
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, AuthResponse>();
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateRequest, User>();
        }
    }
}
