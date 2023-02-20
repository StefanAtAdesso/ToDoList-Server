using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Database;

namespace ToDoListAPI.Repositories
{
    public class ToDoListRepository
    {
        private readonly ToDoContext _db;

        public ToDoListRepository(ToDoContext db)
        {
            _db = db;
        }

        public async Task<IReadOnlyCollection<Category>> GetAllCategories()
        {
            var result = await _db.Categories
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task InsertCategory(string name)
        {
            var newItem = new Category {Name = name};
            await _db.Categories.AddAsync(newItem);
            await _db.SaveChangesAsync();
        }

        public  async Task<IReadOnlyCollection<ToDoItem>>GetAllToDoItems()
        {
            var result = await _db.ToDoItems
                .Include(t => t.Category)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<ToDoItem?> GetToDoItem(int id, bool withTracking = false)
        {
            var query = _db.ToDoItems
                .Include(t => t.Category)
                .AsQueryable();

            if (!withTracking)
            {
                query = query.AsNoTracking();
            }

            var result = await query.FirstOrDefaultAsync(t => t.Id == id);

            return result;
        }

        public async Task<IReadOnlyCollection<ToDoItem>> SearchToDoItems(string pattern)
        {
            var result = await _db.ToDoItems
                .AsNoTracking()
                .Include(t => t.Category)
                .Where(t => t.Titel.Contains(pattern))
                .ToListAsync();
            return result;
        }

        public async Task<ToDoItem> InsertToDoItem(ToDoItem newItem)
        {
            newItem.Created = DateTime.Now;
            newItem.Id = 0;

            var entity = _db.ToDoItems.Attach(newItem);
            entity.State = EntityState.Added;

            await _db.SaveChangesAsync();
            return newItem;
        }

        public async Task<ToDoItem?> UpdateToDoItem(ToDoItem updatedItem)
        {
            var oldItem = await GetToDoItem(updatedItem.Id);
            if (oldItem == null)
            {
                return null;
            }

            var entity = _db.ToDoItems.Attach(updatedItem);
            entity.State = EntityState.Modified;


            await _db.SaveChangesAsync();
            return updatedItem;
        }

        public async Task<bool> DeleteToDoItem(int id)
        {
            var old = await GetToDoItem(id);
            if (old == null)
            {
                return false;
            }

            _db.ToDoItems.Remove(old);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
