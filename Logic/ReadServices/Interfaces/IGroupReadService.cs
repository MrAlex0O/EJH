using DataBase.Models;
using Logic.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface IGroupReadService
    {
        public Task<IEnumerable<GetGroupResponse>> GetAll();
        public Task<GetGroupResponse> Get(Guid id);
    }
}
