using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentDbWpf.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public OrderEntity? Orders { get; set; }
    }
}
