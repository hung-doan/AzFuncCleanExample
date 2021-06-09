using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Ports.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
    }
}
