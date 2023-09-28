using crud_restapi_challenge.Entities;

namespace crud_restapi_challenge.Dao.Interfaces
{
    public interface IItemDao
    {
        Task<Item> SaveAsync(Item item);
        Task<Item> FindByIdAsync(long id);
        Task<IEnumerable<Item>> FindAllAsync();
        Task DeleteByIdAsync(long id);
    }
}
