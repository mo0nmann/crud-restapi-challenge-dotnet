using crud_restapi_challenge.Entities;
using crud_restapi_challenge.Repositories.Interfaces;
using crud_restapi_challenge.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace crud_restapi_challenge.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemAsync(long id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task AddItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(long id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                // Handle not found case, for example, throw an exception or return.
                throw new NotFoundException($"Item with id {id} not found.");
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

    }
}
