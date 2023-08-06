using UrunYonetimCore6584.Core.Entities;
using UrunYonetimCore6584.Data.Abstract;

namespace UrunYonetimCore6584.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
