using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            
        }

        public async Task<int> CreateduserAsync(User user)
        {
           using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();

                parameters.Add("@Username", user.Username);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Role", user.Role);
                parameters.Add("@Status", user.Status);
                parameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("SpInsertUserWithSalt",parameters,commandType:CommandType.StoredProcedure);

                return parameters.Get<int>("@UserId");
            }
        }

    }
}
