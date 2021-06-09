using System.Threading.Tasks;
using Core.Application.UseCases.Products.Commands.Models;

namespace Core.Application.UseCases.Products.Commands
{
    public interface IProductCommandHandler
    {
        Task HandleAsync(CreateProductCommand command);
    }
}
