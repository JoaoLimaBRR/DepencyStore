using DependencyStore.Models;

namespace DependencyStore.DataProviders.Repositories.Contracts
{
    public interface ICustumerRepository
    {
        Task<Customer> GetById(string custumerId);
    }
}
