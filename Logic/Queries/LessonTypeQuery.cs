using Dapper;
using Logic.DTOs.LessonType;
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
    public class LessonTypeQuery : ILessonTypeQuery
    {
        string _connectionString;
        public LessonTypeQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetLessonTypeResponse>> GetAll()
        {
            string querry = $@"SELECT ""Id"", ""Name"" FROM ""LessonTypes""
                                ORDER BY ""DateCreate"" ASC";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonTypeResponse>(querry);
                return await res;
            }
        }
        public async Task<GetLessonTypeResponse> Get(Guid id)
        {
            string querry = $@"SELECT ""Id"", ""Name"" FROM ""LessonTypes""
                                WHERE ""Id"" = '{id}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetLessonTypeResponse>(querry);
                return (await res).FirstOrDefault();
            }
        }
    }
}
