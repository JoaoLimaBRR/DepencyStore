using Dapper;
using DependencyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories
{
    public class CustumerRepository
    {
        private readonly SqlConnection _sqlConnection;

        public CustumerRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<Customer> GetById(string customerId)
        {
            // #1 - Recupera o cliente
            Customer customer = null;
            await using (var conn = _sqlConnection)
            {
                const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
                return customer = await conn.QueryFirstOrDefaultAsync<Customer>(query,
                        new { id = customerId }
                    );
            }
        }
    }
}
