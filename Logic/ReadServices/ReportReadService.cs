using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Enums;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Logic.Queries.Interfaces;
using Logic.DTOs.Report;

namespace Logic.ReadServices
{
    public class ReportReadService : IReportReadService
    {
        private IReportQuery _reportQuery;

        public ReportReadService(IReportQuery reportQuery)
        {
            _reportQuery = reportQuery;
        }

        public List<GetDisciplineVisitsReportResponse> GetDisciplineVisits(Guid disciplineId)
        {
            return _reportQuery.GetDisciplineVisits(disciplineId);
        }
    }
}