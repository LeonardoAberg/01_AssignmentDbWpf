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
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task Create(ProductEntity model)
        {
            var productEntity = new ProductEntity
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Price = model.Price
            };
            _context.Add(productEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            var products = new List<ProductEntity>();
            foreach (var product in await _context.Products.ToListAsync())
                products.Add(new ProductEntity { Id = product.Id, ProductName = product.ProductName, Description = product.Description, Price = product.Price });
            return products;
        }
    }
}
