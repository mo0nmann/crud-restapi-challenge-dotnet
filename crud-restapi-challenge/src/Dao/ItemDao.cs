using crud_restapi_challenge.Dao.Interfaces;
using crud_restapi_challenge.Entities;
using crud_restapi_challenge.Repositories.Interfaces;

namespace crud_restapi_challenge.Dao
{
    public class ItemDao : IItemDao
    {
        private readonly IItemRepository _itemRepository;

        public ItemDao(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> SaveAsync(Item item)
        {
            // 0 is the default value (uninitialised)
            if (item.Id == 0) 
            {
                await _itemRepository.AddItemAsync(item);
            }
            else
            {
                await _itemRepository.UpdateItemAsync(item);
            }
            return item;
        }

        public async Task<Item> FindByIdAsync(long id)
        {
            return await _itemRepository.GetItemAsync(id);
        }

        public async Task<IEnumerable<Item>> FindAllAsync()
        {
            return await _itemRepository.GetAllItemsAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }
    }
}
