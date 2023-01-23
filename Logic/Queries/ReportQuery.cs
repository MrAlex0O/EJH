﻿using Dapper;
using Logic.DTOs.Report;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries
{
    public class ReportQuery : IReportQuery
    {
        string _connectionString;
        public ReportQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public List<GetDisciplineVisitsReportResponse> GetDisciplineVisits(Guid disciplineId)
        {
            string querry = $@"SELECT DISTINCT ""Persons"".""Surname"" || ' ' || ""Persons"".""Name"" || ' ' || ""Persons"".""Midname"" AS ""FullName""
, sum(count(""StatusOnLessons"".""Id"") FILTER(WHERE ""StatusOnLessons"".""EnumId"" = 1)) OVER(PARTITION BY ""Persons"".""Surname"") AS ""Present""
, sum(count(""StatusOnLessons"".""Id"") FILTER(WHERE ""StatusOnLessons"".""EnumId"" = 2)) OVER(PARTITION BY ""Persons"".""Surname"") AS ""Missing""
, sum(count(""StatusOnLessons"".""Id"") FILTER(WHERE ""StatusOnLessons"".""EnumId"" = 3)) OVER(PARTITION BY ""Persons"".""Surname"") AS ""Liberation""
, sum(count(""StatusOnLessons"".""Id"") FILTER(WHERE ""StatusOnLessons"".""EnumId"" = 4)) OVER(PARTITION BY ""Persons"".""Surname"") AS ""AnotherSubgroup""
, sum(count(""StatusOnLessons"".""Id"") FILTER(WHERE ""StatusOnLessons"".""EnumId"" = 5)) OVER(PARTITION BY ""Persons"".""Surname"") AS ""SeriousReason""
, sum(count(""StatusOnLessons"".""Id"") FILTER(WHERE ""StatusOnLessons"".""EnumId"" = 6)) OVER(PARTITION BY ""Persons"".""Surname"") AS ""Incalculable""

FROM ""LessonsVisitors""
INNER JOIN ""Students"" ON ""Students"".""Id"" = ""LessonsVisitors"".""StudentId""
INNER JOIN ""Persons"" ON ""Persons"".""Id"" = ""Students"".""PersonId""
INNER JOIN ""Lessons"" ON ""Lessons"".""Id"" = ""LessonsVisitors"".""LessonId""
INNER JOIN ""StatusOnLessons"" ON ""StatusOnLessons"".""Id"" = ""LessonsVisitors"".""StatusOnLessonId""
WHERE ""Lessons"".""DisciplineId"" = '{disciplineId}'
GROUP BY ""Persons"".""Surname"", ""Persons"".""Name"", ""Persons"".""Midname"", ""StatusOnLessons"".""Name""
ORDER BY 1";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<GetDisciplineVisitsReportResponse>(querry).ToList();
            }
        }
    }
}

