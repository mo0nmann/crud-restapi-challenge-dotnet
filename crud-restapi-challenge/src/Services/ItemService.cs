using crud_restapi_challenge.Adaptors;
using crud_restapi_challenge.Dao.Interfaces;
using crud_restapi_challenge.Dto;
using crud_restapi_challenge.Services.Interfaces;

namespace crud_restapi_challenge.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemDao _itemDao;

        public ItemService(IItemDao itemDao)
        {
            _itemDao = itemDao;
        }

        public async Task<ItemDto> SaveItem(InputtedItemDto itemDto)
        {
            var item = ItemAdaptor.ToEntity(itemDto);
            await _itemDao.SaveAsync(item);
            return ItemAdaptor.ToDto(item);
        }

        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = await _itemDao.FindAllAsync();
            return items.Select(ItemAdaptor.ToDto);
        }

        public async Task<ItemDto> GetItem(long id)
        {
            var item = await _itemDao.FindByIdAsync(id);
            return item == null ? null : ItemAdaptor.ToDto(item);
        }

        public async Task UpdateItem(long id, string name, string description)
        {
            var item = await _itemDao.FindByIdAsync(id);
            if (item != null)
            {
                item.Name = name;
                item.Description = description;
                await _itemDao.SaveAsync(item);
            }
        }

        public async Task DeleteItem(long id)
        {
            await _itemDao.DeleteByIdAsync(id);
        }
    }
}
