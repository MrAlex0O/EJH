using Logic.DTOs.Group;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices
{
    public class GroupReadService : IGroupReadService
    {
        IGroupQuery _groupQuery;
        public GroupReadService(IGroupQuery query)
        {
            _groupQuery = query;
        }
        public async Task<IEnumerable<GetGroupResponse>> GetAll()
        {
            return await _groupQuery.GetAll();
        }
        public async Task<GetGroupResponse> Get(Guid id)
        {
            return await _groupQuery.Get(id);
        }
    }
}
