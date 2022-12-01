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
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerEntity model)
        {
            var customerEntity = new CustomerEntity
            {
                Name = model.Name,
                Email = model.Email
            };
            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            var customers = new List<CustomerEntity>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerEntity { Id = customer.Id, Name = customer.Name, Email = customer.Email });
            return (customers);
        }

        public async Task<CustomerEntity> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new CustomerEntity { Id = customerEntity.Id, Name = customerEntity.Name, Email = customerEntity.Email };
            return null!;
        }

    }
}
