﻿using Dapper;
using Logic.DTOs.LessonVisitor;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Logic.Queries
{
    public class LessonVisitorQuery : ILessonVisitorQuery
    {
        string _connectionString;
        public LessonVisitorQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetLessonVisitorResponse>> GetAll()
        {
            string query = $@"SELECT ""Disciplines"".""Id"" AS ""DisciplineId"", ""Disciplines"".""Name"" AS ""DisciplineName"",
		                        ""Lessons"".""Date"", ""Lessons"".""Id"" AS ""LessonId"",
		                        ""LessonTypes"".""Id"" AS ""LessonTypeId"", ""LessonTypes"".""Name"" AS ""LessonTypeName"",
		                        array_remove(array_agg(""Students"".""Id""), null) AS ""StudentsIds"",
                                array_remove(array_agg(""LessonsVisitors"".""Id""), null) AS ""LessonsVisitorsIds"",
		                        array_remove(array_agg(""Persons"".""Surname"" || ' ' || ""Persons"".""Name"" || ' ' || ""Persons"".""Midname""), null) AS ""StudentFullName"",
		                        array_remove(array_agg(""LessonsVisitors"".""StatusOnLessonId""), null) AS ""StudentStatusesIds"",
		                        array_remove(array_agg(""StatusOnLessons"".""Name""), null) AS ""StudentStatusesNames""
                            FROM ""LessonsVisitors""
                            LEFT JOIN ""Lessons"" ON ""Lessons"".""Id"" = ""LessonsVisitors"".""LessonId""
                            LEFT JOIN ""Disciplines"" ON ""Disciplines"".""Id"" = ""Lessons"".""DisciplineId""
                            LEFT JOIN ""LessonTypes"" ON ""LessonTypes"".""Id"" = ""Lessons"".""LessonTypeId""
                            LEFT JOIN ""Students"" ON ""Students"".""Id"" = ""LessonsVisitors"".""StudentId""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Students"".""PersonId""
                            LEFT JOIN ""StatusOnLessons"" ON ""StatusOnLessons"".""Id"" = ""LessonsVisitors"".""StatusOnLessonId""
                            GROUP BY ""Disciplines"".""Id"", ""Disciplines"".""Name"",
		                            ""Lessons"".""Date"", ""Lessons"".""Id"",
		                            ""LessonTypes"".""Id"", ""LessonTypes"".""Name""";
            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonVisitorResponse>(query);
                return await res;
            }
        }
        public async Task<GetLessonVisitorResponse> GetByLessonId(Guid id)
        {
            string query = $@"SELECT  ""Disciplines"".""Id"" AS ""DisciplineId"", ""Disciplines"".""Name"" AS ""DisciplineName"",
		                        ""Lessons"".""Date"", ""Lessons"".""Id"" AS ""LessonId"",
		                        ""LessonTypes"".""Id"" AS ""LessonTypeId"", ""LessonTypes"".""Name"" AS ""LessonTypeName"",
		                        array_remove(array_agg(""Students"".""Id""), null) AS ""StudentsIds"",
                                array_remove(array_agg(""LessonsVisitors"".""Id""), null) AS ""LessonsVisitorsIds"",
		                        array_remove(array_agg(""Persons"".""Surname"" || ' ' || ""Persons"".""Name"" || ' ' || ""Persons"".""Midname""), null) AS ""StudentFullName"",
		                        array_remove(array_agg(""LessonsVisitors"".""StatusOnLessonId""), null) AS ""StudentStatusesIds"",
		                        array_remove(array_agg(""StatusOnLessons"".""Name""), null) AS ""StudentStatusesNames""
                            FROM ""LessonsVisitors""
                            LEFT JOIN ""Lessons"" ON ""Lessons"".""Id"" = ""LessonsVisitors"".""LessonId""
                            LEFT JOIN ""Disciplines"" ON ""Disciplines"".""Id"" = ""Lessons"".""DisciplineId""
                            LEFT JOIN ""LessonTypes"" ON ""LessonTypes"".""Id"" = ""Lessons"".""LessonTypeId""
                            LEFT JOIN ""Students"" ON ""Students"".""Id"" = ""LessonsVisitors"".""StudentId""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Students"".""PersonId""
                            LEFT JOIN ""StatusOnLessons"" ON ""StatusOnLessons"".""Id"" = ""LessonsVisitors"".""StatusOnLessonId""
                            WHERE ""Lessons"".""Id""='{id}'
                            GROUP BY ""Disciplines"".""Id"", ""Disciplines"".""Name"",
		                        ""Lessons"".""Date"", ""Lessons"".""Id"",
		                        ""LessonTypes"".""Id"", ""LessonTypes"".""Name""";
            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonVisitorResponse>(query);
                return (await res).FirstOrDefault();
            }
        }
    }
}
