using DependencyStore.Models;

namespace DependencyStore.DataProviders.Repositories.Contracts
{
    public interface IPromoCodeRepository
    {
        Task<PromoCode?> GetPromoCodeAsync(string promoCode);
    }
}
