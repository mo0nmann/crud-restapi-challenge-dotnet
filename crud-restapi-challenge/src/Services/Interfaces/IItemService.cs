using crud_restapi_challenge.Dto;

namespace crud_restapi_challenge.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> SaveItem(InputtedItemDto itemDto);
        Task<IEnumerable<ItemDto>> GetItems();
        Task<ItemDto> GetItem(long id);
        Task UpdateItem(long id, string name, string description);
        Task DeleteItem(long id);
    }
}
