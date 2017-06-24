using Project.Domain.Entities;

namespace Project.Data.Repositories
{
    public class ProductRepository : BaseContext<Product>, IUnitOfWork<Product>
    {
    }
}
