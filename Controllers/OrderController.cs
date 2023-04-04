using Dapper;
using DependencyStore.DataProviders.Repositories.Contracts;
using DependencyStore.DataProviders.Services;
using DependencyStore.DataProviders.Services.Contracts;
using DependencyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
    private readonly ICustumerRepository _custumerRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;
    private readonly IPromoCodeRepository _promoCodeRepository;

    public OrderController(ICustumerRepository custumerRepository, IDeliveryFeeService deliveryFeeService, IPromoCodeRepository promoCodeRepository)
    {
        _custumerRepository = custumerRepository;
        _deliveryFeeService = deliveryFeeService;
        _promoCodeRepository = promoCodeRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<string> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        var custumer = await _custumerRepository.GetById(customerId);

        var deliveryFee = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);

        var cupom = await _promoCodeRepository.GetPromoCodeAsync(promoCode);

        var discount = cupom?.Value > 0 ? cupom.Value : 0;

        var order = new Order(deliveryFee, discount, new List<Product>());
        return $"Pedido {order.Code} gerado com sucesso!";
    }
}