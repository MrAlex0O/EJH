using DataBase.Models;
using Logic.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface IGroupQuery
    {
        public Task<IEnumerable<GetGroupResponse>> GetAll();
        public Task<GetGroupResponse> Get(Guid id);
    }
}
