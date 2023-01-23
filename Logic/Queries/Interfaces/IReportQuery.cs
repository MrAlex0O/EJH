using Logic.DTOs.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface IReportQuery
    {
        public List<GetDisciplineVisitsReportResponse> GetDisciplineVisits(Guid disciplineId);
    }
}
