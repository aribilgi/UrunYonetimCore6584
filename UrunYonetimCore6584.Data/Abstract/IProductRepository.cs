using System.Linq.Expressions;
using UrunYonetimCore6584.Core.Entities;

namespace UrunYonetimCore6584.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByIncludeAsync(int id);
        Task<Product> GetProductByIncludeAsync(Expression<Func<Product, bool>> expression);
        Task<List<Product>> GetAllProductsByIncludeAsync();
        Task<List<Product>> GetAllProductsByIncludeAsync(Expression<Func<Product, bool>> expression);
    }
}
