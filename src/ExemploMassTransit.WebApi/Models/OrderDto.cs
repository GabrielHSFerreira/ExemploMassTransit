using ExemploMassTransit.Domain.Orders;
using System;

namespace ExemploMassTransit.WebApi.Models
{
    public record OrderDto(
        Guid Id,
        DateTime CreatedAt,
        DateTime ChangedAt,
        string Customer,
        OrderStatus Status);
}