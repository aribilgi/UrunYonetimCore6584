using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UrunYonetimCore6584.Core.Entities;
using UrunYonetimCore6584.Data.Abstract;

namespace UrunYonetimCore6584.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAllProductsByIncludeAsync()
        {
            return await _context.Products.AsNoTracking().Include(p => p.Category).Include(p => p.Brand).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByIncludeAsync(Expression<Func<Product, bool>> expression)
        {
            return await _context.Products.AsNoTracking().Where(expression).Include(p => p.Category).Include(p => p.Brand).ToListAsync();
        }

        public async Task<Product> GetProductByIncludeAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductByIncludeAsync(Expression<Func<Product, bool>> expression)
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).FirstOrDefaultAsync(expression);
        }
    }
}
