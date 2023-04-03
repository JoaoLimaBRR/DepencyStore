using DependencyStore.DataProviders.Services.Contracts;
using RestSharp;

namespace DependencyStore.DataProviders.Services
{
    public class DeliveryFeeService : IDeliveryFeeService
    {
        public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            decimal deliveryFee = 0;
            var client = new RestClient("https://consultafrete.io/cep/");
            var request = new RestRequest()
                .AddJsonBody(new
                {
                    zipCode
                });
            deliveryFee = await client.PostAsync<decimal>(request);
            // Nunca é menos que R$ 5,00
            return deliveryFee < 5 ? 5 : deliveryFee;

    }
}
