using DependencyStore.Models;

namespace DependencyStore.Contracts
{
    public interface ICustumerRepository
    {
        Task<Customer> GetById(string custumerId);
    }
}
