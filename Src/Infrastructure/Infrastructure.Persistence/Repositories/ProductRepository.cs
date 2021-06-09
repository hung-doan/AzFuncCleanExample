using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Ports.Persistence.Repositories;
using Core.Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> AddAsync(Product product)
        {
            return product;
        }
    }
}
