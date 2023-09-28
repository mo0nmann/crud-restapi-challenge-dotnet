using crud_restapi_challenge.Dto;
using crud_restapi_challenge.Entities;

namespace crud_restapi_challenge.Adaptors
{
    public static class ItemAdaptor
    {
        public static Item ToEntity(InputtedItemDto itemDto)
        {
            return new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description
            };
        }

        public static ItemDto ToDto(Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
        }
    }
}
