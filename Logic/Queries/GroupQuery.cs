﻿using Dapper;
using DataBase.Models;
using Logic.DTOs.Group;
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
    public class GroupQuery : IGroupQuery
    {
        string _connectionString;
        public GroupQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<IEnumerable<GetGroupResponse>> GetAll()
        {
            string querry = $@"SELECT ""Id"", ""Name"" FROM ""Groups""
                                ORDER BY ""DateCreate"" ASC";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res =  db.QueryAsync<GetGroupResponse>(querry);
                return await res;
            }
        }
        public async Task<GetGroupResponse> Get(Guid id)
        {
            string querry = $@"SELECT ""Id"", ""Name"" FROM ""Groups""
                                WHERE ""Id"" = '{id}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                var res = db.QueryAsync<GetGroupResponse>(querry);
                return (await res).FirstOrDefault();
            }
        }
    }
}
