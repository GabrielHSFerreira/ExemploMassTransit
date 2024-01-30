using ExemploMassTransit.Domain.Orders;
using ExemploMassTransit.Persistence.Contexts;
using ExemploMassTransit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploMassTransit.WebApi.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ExemploContext _context;

        public OrdersController(ExemploContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public async Task<IActionResult> Submit(SubmitOrder submitOrder, CancellationToken cancellationToken)
        {
            var order = new Order(submitOrder.Id, DateTime.UtcNow, submitOrder.Customer);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return Ok(new { CreatedId = order.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new OrderDto(x.Id, x.CreatedAt, x.ChangedAt, x.Customer, x.Status))
                .ToListAsync(cancellationToken);

            return Ok(new { Data = orders });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(id, cancellationToken);

            if (order == null)
                return NotFound();

            return Ok(new OrderDto(order.Id, order.CreatedAt, order.ChangedAt, order.Customer, order.Status));
        }
    }
}