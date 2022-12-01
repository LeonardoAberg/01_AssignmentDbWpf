using _01_AssignmentDbWpf.Context;
using _01_AssignmentDbWpf.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentDbWpf.Services
{
    public class OrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task Create(OrderEntity model)
        {
            var orderEntity = new OrderEntity
            {
                Id = model.Id,
                Date = DateTime.Now,
                TotalCost = model.TotalCost
            };
            _context.Add(orderEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            var orders = new List<OrderEntity>();
            foreach (var order in await _context.Orders.ToListAsync())
                orders.Add(new OrderEntity { Id = order.Id, Date = order.Date, TotalCost = order.TotalCost });
            return orders;
        }
    }
}
