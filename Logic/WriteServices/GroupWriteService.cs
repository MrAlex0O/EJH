using AutoMapper;
using DataBase.Models;
using DataBase.Repositories.Interfaces;
using Logic.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WriteServices
{
    public class GroupWriteService : IGroupWriteService
    {
        private IUnitOfWorkRepository _repositories;
        readonly IMapper _mapper;
        public GroupWriteService(IUnitOfWorkRepository repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        public void Add(CreateGroupRequest createGroupRequest)
        {
            _repositories.Groups.Add(_mapper.Map<Group>(createGroupRequest));
            _repositories.SaveChanges();
        }
    }
}
