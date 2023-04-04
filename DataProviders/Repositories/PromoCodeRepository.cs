using Dapper;
using DependencyStore.DataProviders.Repositories.Contracts;
using DependencyStore.Models;
using Microsoft.Data.SqlClient;

namespace DependencyStore.DataProviders.Repositories
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly SqlConnection _sqlConnection;
        public PromoCodeRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<PromoCode?> GetPromoCodeAsync(string promoCode)
        {
            const string query = "SELECT * FROM PROMO_CODES WHERE CODE=@code";
            return await _sqlConnection.QueryFirstOrDefaultAsync<PromoCode>(query, new { code = promoCode });
        }
    }
}
