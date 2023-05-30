using Dapper;
using Logic.DTOs.LessonType;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Logic.Queries
{
    public class LessonTypeQuery : ILessonTypeQuery
    {
        string _connectionString;
        public LessonTypeQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetLessonTypeResponse>> GetAll()
        {
            string query = $@"SELECT ""Id"", ""Name"" FROM ""LessonTypes""
                              ORDER BY ""DateCreate"" ASC";
            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonTypeResponse>(query);
                return await res;
            }
        }
        public async Task<GetLessonTypeResponse> Get(Guid id)
        {
            string query = $@"SELECT ""Id"", ""Name"" FROM ""LessonTypes""
                              WHERE ""Id"" = '{id}'";
            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonTypeResponse>(query);
                return (await res).FirstOrDefault();
            }
        }
    }
}
