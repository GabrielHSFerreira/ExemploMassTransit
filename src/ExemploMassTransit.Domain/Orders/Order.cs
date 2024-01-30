using System;

namespace ExemploMassTransit.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime ChangedAt { get; private set; }
        public string Customer { get; init; } = string.Empty;
        public OrderStatus Status { get; private set; }

        private Order() { }

        public Order(Guid id, DateTime createdAt, string customer)
        {
            Id = id;
            CreatedAt = createdAt;
            ChangedAt = createdAt;
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Status = OrderStatus.Submitted;
        }
    }
}