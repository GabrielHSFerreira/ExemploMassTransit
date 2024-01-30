using System;

namespace ExemploMassTransit.WebApi.Models
{
    public record SubmitOrder(
        Guid Id,
        string Customer);
}