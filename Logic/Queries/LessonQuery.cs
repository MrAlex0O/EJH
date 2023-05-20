using Dapper;
using Logic.DTOs.Lesson;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Logic.Queries
{
    public class LessonQuery : ILessonQuery
    {
        string _connectionString;
        public LessonQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetLessonResponse>> GetAll()
        {
            string query = $@"SELECT ""Lessons"".""Id"",
                                        ""Disciplines"".""Id"" AS ""DisciplineId"", ""Disciplines"".""Name"" AS ""Disciplinename"",
                                        l.""Id"" AS ""LectorId"", l1.""Surname"" || ' ' || l1.""Name"" || ' ' || l1.""Midname"" AS ""LectorFullName"",
                                        ""Groups"".""Id"" AS ""GroupId"", ""Groups"".""Name"" AS ""GroupName"",
                                        array_remove(array_agg(a.""Id""), null) AS ""AssistantsIds"",
                                        array_remove(array_agg(a1.""Surname"" || ' ' || a1.""Name"" || ' ' || a1.""Midname""), null) AS ""AssistantsFullNames"",
                                        ""LessonTypes"".""Id"" AS ""LessonTypeId"", ""LessonTypes"".""Name"" AS ""LessonType"",
                                        ""Lessons"".""Date"", ""Lessons"".""SequenceNumber""
                            FROM ""Lessons""

                            LEFT JOIN ""Disciplines"" ON ""Disciplines"".""Id"" = ""Lessons"".""DisciplineId""
                            LEFT JOIN ""Groups"" ON ""Groups"".""Id"" = ""Disciplines"".""GroupId""
                            LEFT JOIN ""Teachers"" AS l ON l.""Id"" = ""Disciplines"".""LectorId""
                            LEFT JOIN ""Persons"" AS l1 ON l1.""Id"" = l.""PersonId""
                            LEFT JOIN ""Assistants"" AS a0 ON a0.""DisciplineId"" = ""Disciplines"".""Id""
                            LEFT JOIN ""Teachers"" AS a ON a.""Id"" = a0.""TeacherId""
                            LEFT JOIN ""Persons"" AS a1 ON a1.""Id"" = a.""PersonId""
                            LEFT JOIN ""LessonTypes"" ON ""LessonTypes"".""Id"" = ""Lessons"".""LessonTypeId""
                            
                            GROUP BY ""Lessons"".""Id"", ""Disciplines"".""Id"", 
		                        l.""Id"", l1.""Surname"" || ' ' || l1.""Name"" || ' ' || l1.""Midname"",
		                        ""Groups"".""Id"", ""Groups"".""Name"",
		                        ""Disciplines"".""Semester"",
							    ""LessonTypes"".""Id"", ""LessonTypes"".""Name"",
                                ""Lessons"".""Date"", ""Lessons"".""SequenceNumber"", ""Lessons"".""DateCreate""
                            
                            ORDER BY ""Lessons"".""DateCreate"" ASC";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonResponse>(query);
                return await res;
            }
        }
        public async Task<GetLessonResponse> Get(Guid id)
        {
            string query = $@"SELECT ""Lessons"".""Id"", 
""Disciplines"".""Id"" AS ""DisciplineId"", ""Disciplines"".""Name"" AS ""Disciplinename"",
l.""Id"" AS ""LectorId"", l1.""Surname"" || ' ' || l1.""Name"" || ' ' || l1.""Midname"" AS ""LectorFullName"",
""Groups"".""Id"" AS ""GroupId"", ""Groups"".""Name"" AS ""GroupName"",
array_remove(array_agg(a.""Id""), null) AS ""AssistantsIds"",
array_remove(array_agg(a1.""Surname"" || ' ' || a1.""Name"" || ' ' || a1.""Midname""), null) AS ""AssistantsFullNames"",
""LessonTypes"".""Id"" AS ""LessonTypeId"", ""LessonTypes"".""Name"" AS ""LessonType"",
""Lessons"".""Date"", ""Lessons"".""SequenceNumber""
                            FROM ""Lessons""

                            LEFT JOIN ""Disciplines"" ON ""Disciplines"".""Id"" = ""Lessons"".""DisciplineId""
                            LEFT JOIN ""Groups"" ON ""Groups"".""Id"" = ""Disciplines"".""GroupId""
                            LEFT JOIN ""Teachers"" AS l ON l.""Id"" = ""Disciplines"".""LectorId""
                            LEFT JOIN ""Persons"" AS l1 ON l1.""Id"" = l.""PersonId""
                            LEFT JOIN ""Assistants"" AS a0 ON a0.""DisciplineId"" = ""Disciplines"".""Id""
                            LEFT JOIN ""Teachers"" AS a ON a.""Id"" = a0.""TeacherId""
                            LEFT JOIN ""Persons"" AS a1 ON a1.""Id"" = a.""PersonId""

                            LEFT JOIN ""LessonTypes"" ON ""LessonTypes"".""Id"" = ""Lessons"".""LessonTypeId""
WHERE ""Lessons"".""Id"" = '{id}'
                            GROUP BY ""Lessons"".""Id"", ""Disciplines"".""Id"", 
		                    l.""Id"", l1.""Surname"" || ' ' || l1.""Name"" || ' ' || l1.""Midname"",
		                    ""Groups"".""Id"", ""Groups"".""Name"",
		                    ""Disciplines"".""Semester"",
							""LessonTypes"".""Id"", ""LessonTypes"".""Name"",
""Lessons"".""Date"", ""Lessons"".""SequenceNumber""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonResponse>(query);
                return (await res).FirstOrDefault();
            }
        }
    }
}
