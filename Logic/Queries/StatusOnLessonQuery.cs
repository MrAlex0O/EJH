using Dapper;
using Logic.DTOs.StatusOnLesson;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Logic.Queries
{
    public class StatusOnLessonQuery : IStatusOnLessonQuery
    {
        string _connectionString;
        public StatusOnLessonQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetStatusOnLessonResponse>> GetAll()
        {
            string query = $@"SELECT ""Id"", ""Name"" FROM ""StatusOnLessons""
                                ORDER BY ""DateCreate"" ASC";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetStatusOnLessonResponse>(query);
                return await res;
            }
        }
        public async Task<GetStatusOnLessonResponse> Get(Guid id)
        {
            string query = $@"SELECT ""Id"", ""Name"" FROM ""StatusOnLessons""
                                WHERE ""Id"" = '{id}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetStatusOnLessonResponse>(query);
                return (await res).FirstOrDefault();
            }
        }
    }
}
