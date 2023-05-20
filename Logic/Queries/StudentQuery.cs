using Dapper;
using Logic.DTOs.Student;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Logic.Queries
{
    public class StudentQuery : IStudentQuery
    {
        string _connectionString;
        public StudentQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetStudentResponse>> GetAll()
        {
            string query = $@"SELECT ""Students"".""Id"", 
                            ""Persons"".""Name"", ""Persons"".""Midname"",""Persons"".""Surname"",""Persons"".""Address"",""Persons"".""Email"",""Persons"".""PhoneNumber"",
		                    ""Groups"".""Id"" AS ""GroupId"", ""Groups"".""Name"" AS ""GroupName""
                            FROM ""Students""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Students"".""PersonId""
                            LEFT JOIN ""Groups"" ON ""Groups"".""Id"" = ""Students"".""GroupId""
                            ORDER BY ""Students"".""DateCreate"" ASC";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {

                var res = db.QueryAsync<GetStudentResponse>(query);
                return await res;
            }
        }
        public async Task<GetStudentResponse> Get(Guid id)
        {
            string query = $@"SELECT ""Students"".""Id"", 
                            ""Persons"".""Name"", ""Persons"".""Midname"",""Persons"".""Surname"",""Persons"".""Address"",""Persons"".""Email"",""Persons"".""PhoneNumber"",
		                    ""Groups"".""Id"" AS ""GroupId"", ""Groups"".""Name"" AS ""GroupName""
                            FROM ""Students""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Students"".""PersonId""
                            LEFT JOIN ""Groups"" ON ""Groups"".""Id"" = ""Students"".""GroupId""
                            WHERE ""Students"".""Id""='{id}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetStudentResponse>(query);
                return (await res).FirstOrDefault();
            }
        }
        public async Task<IEnumerable<GetStudentResponse>> GetByGroupId(Guid groupId)
        {
            string query = $@"SELECT ""Students"".""Id"", 
                            ""Persons"".""Name"", ""Persons"".""Midname"",""Persons"".""Surname"",""Persons"".""Address"",""Persons"".""Email"",""Persons"".""PhoneNumber"",
		                    ""Groups"".""Id"" AS ""GroupId"", ""Groups"".""Name"" AS ""GroupName""
                            FROM ""Students""
                            LEFT JOIN ""Persons"" ON ""Persons"".""Id"" = ""Students"".""PersonId""
                            LEFT JOIN ""Groups"" ON ""Groups"".""Id"" = ""Students"".""GroupId""
                            WHERE ""Groups"".""Id""='{groupId}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetStudentResponse>(query);
                return await res;
            }
        }

    }
}
