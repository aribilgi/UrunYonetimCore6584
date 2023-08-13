using UrunYonetimCore6584.Data;
using UrunYonetimCore6584.Data.Concrete;
using UrunYonetimCore6584.Service.Abstract;

namespace UrunYonetimCore6584.Service.Concrete
{
    public class ProductService : ProductRepository, IProductService
    {
        public ProductService(DatabaseContext context) : base(context)
        {
        }
    }
}
