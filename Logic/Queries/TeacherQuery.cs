using Dapper;
using Logic.DTOs.Teacher;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Logic.Queries
{
    public class TeacherQuery : ITeacherQuery
    {
        string _connectionString;
        public TeacherQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetTeacherResponse>> GetAll()
        {
            string query = $@"SELECT ""Teachers"".""Id"", 
                            ""Persons"".""Name"", ""Persons"".""Midname"",""Persons"".""Surname"",""Persons"".""Address"",""Persons"".""Email"",""Persons"".""PhoneNumber""
                            FROM ""Teachers""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Teachers"".""PersonId""
                            ORDER BY ""Teachers"".""DateCreate"" ASC";
            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetTeacherResponse>(query);
                return await res;
            }
        }
        public async Task<GetTeacherResponse> Get(Guid id)
        {
            string query = $@"SELECT ""Teachers"".""Id"", 
                            ""Persons"".""Name"", ""Persons"".""Midname"",""Persons"".""Surname"",""Persons"".""Address"",""Persons"".""Email"",""Persons"".""PhoneNumber""
                            FROM ""Teachers""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Teachers"".""PersonId""
                            WHERE ""Teachers"".""Id""='{id}'";
            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetTeacherResponse>(query);
                return (await res).FirstOrDefault();
            }
        }
    }
}
