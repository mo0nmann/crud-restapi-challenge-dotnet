using Microsoft.AspNetCore.Mvc;
using crud_restapi_challenge.Dto;
using crud_restapi_challenge.Services.Interfaces;

namespace crud_restapi_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> SaveItem([FromBody] InputtedItemDto itemDto)
        {
            var item = await _itemService.SaveItem(itemDto);
            return Ok(item);
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
        {
            var items = await _itemService.GetItems();
            return Ok(items);
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(long id)
        {
            var itemDto = await _itemService.GetItem(id);
            if (itemDto == null)
            {
                return NotFound();
            }
            return Ok(itemDto);
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, [FromBody] ItemDto itemDto)
        {
            await _itemService.UpdateItem(id, itemDto.Name, itemDto.Description);
            return Ok();
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            await _itemService.DeleteItem(id);
            return Ok();
        }
    }
}
