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
        IGroupQuery _query;
        public GroupReadService(IGroupQuery query)
        {
            _query = query;
        }
        public List<GetGroupResponse> GetAll()
        {
            return _query.GetAll();
        }
        public GetGroupResponse Get(Guid id)
        {
            return _query.Get(id);
        }
    }
}
